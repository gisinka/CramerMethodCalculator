using System.Collections.Generic;
using Lab4.Core;
using NUnit.Framework;

namespace Lab4.Tests
{
    [TestFixture]
    internal class EquationsSystemSolveTests
    {
        private static readonly Dictionary<string, double[,]> MatricesStorage = new Dictionary<string, double[,]>
        {
            {"dataset1", new double[,] {{3, -2, 4, 21}, {3, 4, -2, 9}, {2, -1, -1, 10}}},
            {"dataset2", new double[,] {{2, -3, 1, 2}, {2, 1, -4, 9}, {6, -5, 2, 17}}},
            {"dataset3", new double[,] {{1, 0, 1, 4}, {0, 2, -1, 1}, {3, -1, 0, 1}}},
            {"dataset4", new double[,] {{2, 3, -4, 1, 0}, {1, 0, 0, 1, -1}, {-1, -1, 2, -1, 1}, {2, -1, -1, 2, -2}}},
            {"dataset5", new double[,] {{1, 2, 1, -1}, {3, -1, -1, -1}, {-2, 2, 3, 5}}},
            {"dataset6", new double[,] {{7, -2, -1, 2}, {6, -4, -5, 3}, {1, 2, 4, 5}}},
            {"dataset7", new double[,] {{2, -1, 3, 9}, {3, -5, 1, -4}, {4, -7, 1, 5}}},
            {"dataset8", new double[,] {{2, 3, -1, 1, 1}, {8, 12, -9, 8, 3}, {4, 6, 3, -2, 3}, {2, 3, 9, -7, 3}}},
            {"dataset9", new double[,] {{1, 3, -2, -2, -3}, {-1, -2, 1, 2, 2}, {-2, -1, 3, 1, -2}, {-3, -2, 3, 3, -1}}}
        };

        private static readonly Dictionary<string, List<double>> AnswersStorage = new Dictionary<string, List<double>>
        {
            {"dataset1", new List<double> {5, -1, 1}},
            {"dataset2", new List<double> {5, 3, 1}},
            {"dataset3", new List<double> {1, 2, 3}},
            {"dataset4", new List<double> {1, 0, 0, -2}},
            {"dataset5", new List<double> {0, -2, 3}},
        };

        [TestCase("dataset1")]
        [TestCase("dataset2")]
        [TestCase("dataset3")]
        [TestCase("dataset4")]
        [TestCase("dataset5")]
        public static void EquationsSolveTest(string key)
        {
            Assert.AreEqual(AnswersStorage[key], new Matrix(MatricesStorage[key]).SolveEquations());
        }

        [TestCase("dataset6")]
        [TestCase("dataset7")]
        public static void InconsistentSystemTest(string key)
        {
            Assert.AreEqual(new List<double> {0}, new Matrix(MatricesStorage[key]).SolveEquations());
        }

        [TestCase("dataset8")]
        [TestCase("dataset9")]
        public static void InfinityNumberSolutionTest(string key)
        {
            Assert.AreEqual(new List<double>(), new Matrix(MatricesStorage[key]).SolveEquations());
        }
    }
}