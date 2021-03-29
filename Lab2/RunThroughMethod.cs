using System;
using System.Collections.Generic;
using System.Text;
using LinearSystemSolver;
namespace Lab2to8
{
    class RunThroughMethod : ISystemSolver
    {
        public double[] Solve(int rank, double[][] elements, double[] column)
        {
            double[] A = new double[rank];
            double[] B = new double[rank];

            A[0] = -elements[0][1]/elements[0][0];
            B[0] = column[0] / elements[0][0];

            // прямой ход
            for (int i = 1; i < rank - 1; i++)
            {
                A[i] = -elements[i][i + 1] / (elements[i][i] + elements[i][i - 1] * A[i - 1]);
                B[i] = (column[i] - elements[i][i - 1] * B[i - 1]) / (elements[i][i] + elements[i][i - 1] * A[i - 1]);
            }

            // обратный ход
            double[] x = new double[rank];
            x[rank - 1] = (column[rank - 1] - elements[rank - 1][rank - 2]*B[rank-2]) / (elements[rank - 1][rank - 1] + elements[rank - 1][rank - 2] * A[rank - 2]);
            for (int i = rank - 2; i >= 0; i--) 
            {
                x[i] = A[i] * x[i + 1] + B[i];
            }
            return x;
        }
    }
}
