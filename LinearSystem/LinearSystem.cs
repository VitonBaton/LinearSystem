using System;
using System.Collections.Generic;

namespace LinearSystemSolver
{
    public class LinearSystem
    {
        private double[][] elements;
        private double[] column;
        private int rank;
        public LinearSystem()
        {
            Console.Write("Input rank of system: ");
            rank = Convert.ToInt32(Console.ReadLine());

            column = new double[rank];
            elements = new double[rank][];
            for (int i = 0; i < rank; i++)
                elements[i] = new double[rank];
            
            Console.WriteLine("Inputing elements...");
            for (int i = 0; i < rank; i++)
            {
                Console.WriteLine("Input {0} row", i + 1);
                var tempValues = Console.ReadLine().Split(' ');
                for (int j = 0; j < rank; j++)
                    elements[i][j] = Convert.ToDouble(tempValues[j]);
                column[i] = Convert.ToDouble(tempValues[rank]);
            }
        }

        public LinearSystem(double[][] elements,
                            double[] column,
                            int rank)
        {
            this.elements = elements;
            this.column = column;
            this.rank = rank;
        }

        public double[] Solve(ISystemSolver solver)
        {
            if (solver != null)
                return solver.Solve(rank, elements, column);
            else
                return null;
        }

        public void Print()
        {
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank - 1; j++)
                {
                    Console.Write("{0} x{1} + ", elements[i][j], j + 1);
                }
                Console.WriteLine("{0} x{1} = {2}", elements[i][rank - 1], rank, column[i]);
            }
        }

        public bool IsDominance()
        {
            bool ret = true;
            for (int i = 0; i < rank && ret; i++)
            {
                double coeff = 0;
                for (int j = 0; j < i; j++)
                    coeff += Math.Abs(elements[i][j]);
                for (int j = i + 1; j < rank; j++) 
                    coeff += Math.Abs(elements[i][j]);
                ret = Math.Abs(elements[i][i]) > coeff;
            }
            return ret;
        }
    }

    public interface ISystemSolver
    {
        public double[] Solve(int rank, double[][] elements, double[] column);
    }
}
