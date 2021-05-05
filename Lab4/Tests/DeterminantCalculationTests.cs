using System.Collections.Generic;
using Lab4.Core;
using NUnit.Framework;

namespace Lab4.Tests
{
    [TestFixture]
    internal static class DeterminantCalculationTests
    {
        private static readonly Dictionary<string, double[,]> MatricesStorage = new Dictionary<string, double[,]>
        {
            {"dataset1", new double[,] {{1}}},
            {"dataset2", new double[,] {{-2, 3}, {-4, 5}}},
            {"dataset3", new double[,] {{-4, -1, 2}, {10, 4, -1}, {8, 3, 1}}},
            {"dataset4", new double[,] {{3, -3, -5, 8}, {-3, 2, 4, -6}, {2, -5, -7, 5}, {-4, 3, 5, -6}}},
            {
                "dataset5",
                new double[,] {{-1, -4, 0, 0, -2}, {0, 1, 1, 5, 4}, {3, 1, 7, 1, 0}, {0, 0, 2, 0, -3}, {-1, 0, 4, 2, 2}}
            },
            {"redheffer1", new double[,] {{1, 1}, {1, 1}}},
            {"redheffer2", new double[,] {{1, 1, 1}, {1, 1, 0}, {1, 0, 1}}},
            {"redheffer3", new double[,] {{1, 1, 1, 1}, {1, 1, 0, 1}, {1, 0, 1, 0}, {1, 0, 0, 1}}},
            {
                "redheffer4",
                new double[,] {{1, 1, 1, 1, 1}, {1, 1, 0, 1, 0}, {1, 0, 1, 0, 0}, {1, 0, 0, 1, 0}, {1, 0, 0, 0, 1}}
            },
            {
                "redheffer5",
                new double[,]
                {
                    {1, 1, 1, 1, 1, 1}, {1, 1, 0, 1, 0, 1}, {1, 0, 1, 0, 0, 1}, {1, 0, 0, 1, 0, 0}, {1, 0, 0, 0, 1, 0},
                    {1, 0, 0, 0, 0, 1}
                }
            }
        };

        [TestCase("dataset1", 1)]
        [TestCase("dataset2", 2)]
        [TestCase("dataset3", -14)]
        [TestCase("dataset4", 18)]
        [TestCase("dataset5", 996)]
        public static void UsualDeterminantCalculationTest(string key, double expected)
        {
            Assert.AreEqual(expected, new Matrix(MatricesStorage[key]).CalculateDeterminant());
        }

        [TestCase("redheffer1", 0)]
        [TestCase("redheffer2", -1)]
        [TestCase("redheffer3", -1)]
        [TestCase("redheffer4", -2)]
        [TestCase("redheffer5", -1)]
        public static void RedhefferMatrixDeterminantCalculationTest(string key, double expected)
        {
            Assert.AreEqual(expected, new Matrix(MatricesStorage[key]).CalculateDeterminant());
        }
    }
}