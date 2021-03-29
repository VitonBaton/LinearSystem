using System;
using System.Collections.Generic;
using System.Text;
using LinearSystemSolver;

namespace Lab2to8
{
    class SeidelMethod : ISystemSolver
    {
        public double[] Solve(int rank, double[][] elements, double[] column)
        {
            double[][] B = new double[rank][];
            for (int i = 0; i < rank; i++)
                B[i] = new double[rank];

            for (int i = 0; i < rank; i++)
                for (int j = 0; j < rank; j++)
                {
                    if (i == j)
                        B[i][j] = 0;
                    else
                        B[i][j] = -elements[i][j] / elements[i][i];
                }

            for (int i = 0; i < rank; i++)
                column[i] /= elements[i][i];
            double[] X = new double[rank];
            double[] Xtemp = (double[])column.Clone();
            double max;
            int counter = 0;
            do
            {
                counter++;
                max = 0;
                double[] testAccuracy = new double[rank];
                for (int i = 0; i < rank; i++)
                {
                    double coeff = 0;
                    for (int k = 0; k < rank; k++)
                    {
                        coeff += B[i][k] * Xtemp[k];
                    }
                    X[i] = coeff + column[i];
                    testAccuracy[i] = Math.Abs(X[i] - Xtemp[i]);
                    if (testAccuracy[i] > max)
                    {
                        max = testAccuracy[i];
                    }
                    Xtemp[i] = X[i];
                }
            } while (max >= 0.001);
            Console.WriteLine(counter);
            return X;
        }
    }
}
