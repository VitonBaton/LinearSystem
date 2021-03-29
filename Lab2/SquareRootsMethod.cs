using LinearSystemSolver;
using System.Collections.Generic;
using System.Text;
using System;

namespace Lab2to8
{
    class SquareRootsMethod : ISystemSolver
    {
        public double[] Solve(int rank, double[][] elements, double[] column)
        {
            double[][] sMatrix = new double[rank][];
            for (int i = 0; i < rank; i++)
                sMatrix[i] = new double[rank];

            // матрица S
            double coeff;
            double[] d = new double[rank];
            for (int i = 0; i < rank; i++)
            {
                coeff = 0;
                for (int k = 0; k < i; k++)
                {
                    coeff += sMatrix[k][i] * sMatrix[k][i] * d[k];
                }
                d[i] = Math.Sign(elements[i][i] - coeff);
                sMatrix[i][i] = Math.Sqrt(Math.Abs(elements[i][i] - coeff));

                for (int j = i + 1; j < rank; j++)
                {
                    coeff = 0;
                    for (int k = 0; k < i; k++)
                    {
                        coeff += sMatrix[k][i] * sMatrix[k][j]*d[k];
                    }
                    sMatrix[i][j] = (elements[i][j] - coeff) / (sMatrix[i][i] *d[i]);
                }

            }
            // вектор Y
            double[] y = new double[rank];
            for (int i = 0; i < rank; i++)
            {
                coeff = 0;
                for (int k = 0; k < i; k++)
                    coeff += y[k] * sMatrix[k][i]*d[k];
                y[i] = (column[i] - coeff) / (sMatrix[i][i] * d[i]);
            }
            // вектор Х
            double[] x = new double[rank];
            for (int i = rank - 1; i >= 0; i--)
            {
                coeff = 0;
                for (int k = i + 1; k < rank; k++)
                {
                    coeff += sMatrix[i][k] * x[k];
                }
                x[i] = ((y[i] - coeff)) / sMatrix[i][i];
            }
            return x;
        }
    }
}
