using System.Collections.Generic;
using System.Linq;

namespace Lab4.Core
{
    internal static class EquationsSystemSolver
    {
        public static List<double> SolveEquations(this Matrix matrix)
        {
            var determinants = new List<double>();
            var determinant = matrix
                .CreateMatrixWithoutColumn(matrix.N - 1)
                .CalculateDeterminant();

            for (var i = 0; i < matrix.N - 1; i++)
            {
                var tempMatrix = matrix.SwapColumns(i, matrix.N - 1).CreateMatrixWithoutColumn(matrix.N - 1);
                var iDeterminant = tempMatrix.CalculateDeterminant();
                determinants.Add(iDeterminant);
            }

            switch (determinant)
            {
                case 0 when determinants.Count(x => x != 0) > 0:
                    return new List<double> {0};
                case 0 when determinants.Count(x => x != 0) == 0:
                    return new List<double>();
                default:
                    return determinants.Select(x => x / determinant).ToList();
            }
        }
    }
}