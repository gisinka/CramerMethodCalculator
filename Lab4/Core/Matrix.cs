using System;

namespace Lab4.Core
{
    internal class Matrix
    {
        private readonly double[,] _data;
        private double _precalculatedDeterminant = double.NaN;

        public int M { get; }
        public int N { get; }
        public bool IsSquare => M == N;

        public double this[int x, int y]
        {
            get => _data[x, y];
            set
            {
                _data[x, y] = value;
                _precalculatedDeterminant = double.NaN;
            }
        }

        public Matrix(int m, int n)
        {
            M = m;
            N = n;
            _data = new double[m, n];
            ProcessFunctionOverData((i, j) => _data[i, j] = 0);
        }

        public Matrix(int m)
        {
            M = m;
            N = m;
            _data = new double[m, m];
            ProcessFunctionOverData((i, j) => _data[i, j] = 0);
        }

        public Matrix(double[,] data)
        {
            M = data.GetLength(0);
            N = data.GetLength(1);
            _data = data;
        }

        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < M; i++)
            for (var j = 0; j < N; j++)
                func(i, j);
        }

        public double CalculateDeterminant()
        {
            if (!double.IsNaN(_precalculatedDeterminant)) return _precalculatedDeterminant;
            if (!IsSquare)
                throw new InvalidOperationException("determinant can be calculated only for square matrices");
            switch (N)
            {
                case 1:
                    return this[0, 0];
                case 2:
                    return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
            }

            double result = 0;
            for (var j = 0; j < N; j++)
                result += (j % 2 == 1 ? 1 : -1) * this[1, j] *
                          CreateMatrixWithoutColumn(j).CreateMatrixWithoutRow(1).CalculateDeterminant();
            _precalculatedDeterminant = result;
            return result;
        }

        public Matrix CreateMatrixWithoutRow(int row)
        {
            if (row < 0 || row >= M) throw new ArgumentException("invalid row index");
            var result = new Matrix(M - 1, N);
            result.ProcessFunctionOverData((i, j) => result[i, j] = i < row ? this[i, j] : this[i + 1, j]);
            return result;
        }

        public Matrix CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= N) throw new ArgumentException("invalid column index");
            var result = new Matrix(M, N - 1);
            result.ProcessFunctionOverData((i, j) => result[i, j] = j < column ? this[i, j] : this[i, j + 1]);
            return result;
        }

        public Matrix SwapColumns(int firstColumn, int secondColumn)
        {
            if (firstColumn < 0 || secondColumn >= N || secondColumn < 0 || secondColumn >= N)
                throw new ArgumentException("invalid column index");
            var copy = (double[,]) _data.Clone();
            for (var i = 0; i < M; i++)
            {
                var temp = copy[i, firstColumn];
                copy[i, firstColumn] = copy[i, secondColumn];
                copy[i, secondColumn] = temp;
            }

            return new Matrix(copy);
        }
    }
}