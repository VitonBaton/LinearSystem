using LinearSystemSolver;

namespace Lab2to8
{
    class GaussMethod : ISystemSolver
    {
        public double[] Solve(int rank, double[][] elements, double[] column)
        {
            // k - current column/row
            for (int k = 0; k < rank; k++)
            {
                // j - under current row
                for (int j = k + 1; j < rank; j++)
                {
                    // div all elements in this row by key element
                    var coeff = elements[j][k] / elements[k][k];
                    for (int i = k; i < rank; i++)
                    {
                        elements[j][i] -= coeff * elements[k][i];
                    }
                    column[j] -= coeff * column[k];
                }
            }


            double[] x = new double[rank];          // x - vector of answers
            for (int i = rank - 1; i >= 0; i--)
            {
                double coeff = 0;
                for (int j = i + 1; j < rank; j++)
                {
                    coeff += elements[i][j] * x[j];
                }
                x[i] = ((column[i] - coeff)) / elements[i][i];
            }
            return x;
        }
    }
}
