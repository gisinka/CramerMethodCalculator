using System;
using Lab4.Core;

namespace Lab4
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите количество уравнений:");
            var dimension = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var matrix = new Matrix(dimension, dimension + 1);
            for (var i = 0; i < dimension; i++)
            for (var j = 0; j <= dimension; j++)
            {
                Console.WriteLine($"Введите {j + 1} коэффициент {i + 1} уравнения");
                matrix[i, j] = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }

            var result = matrix.SolveEquations();

            switch (result.Count)
            {
                case 0:
                    Console.WriteLine("Система имеет бесконечное множество решений");
                    break;
                case 1:
                    Console.WriteLine(result[0] == 0
                        ? "Система несовместна"
                        : $"X1 = {result[0]}");
                    break;
                default:
                    for (var i = 0; i < result.Count; i++) Console.Write($"X{i + 1} = {result[i]} ");
                    Console.WriteLine();
                    break;
            }

            Console.ReadKey();
        }
    }
}