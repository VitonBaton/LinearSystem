using System;
using LinearSystemSolver;

namespace Lab2to8
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearSystem system = new LinearSystem();
            Console.WriteLine();
            system.Print();
            //if (!system.IsDominance())
            //{
            //    Console.WriteLine("System doesn't have diagonal dominance. Simple Iterations and Seidel Method not working");
            //}
            //else
            //{
                var result = system.Solve(new SquareRootsMethod());
                Console.Write("\nAnswer:");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write("\nx{0} = {1} ", i + 1, result[i]);
                }
            //}
        }
    }
}
