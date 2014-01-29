using System;
using System.Collections.Generic;

namespace SpiralMatrixTraversal
{
    public class MatrixTraverser
    {
        private enum Direction
        {
            Up,
            Left,
            Down,
            Right
        }

        private readonly Dictionary<Direction, Direction> _nextDirection = new Dictionary<Direction, Direction>
        {
            { Direction.Up, Direction.Left },
            { Direction.Left, Direction.Down },
            { Direction.Down, Direction.Right },
            { Direction.Right, Direction.Up }
        };

        private readonly Dictionary<Direction, Tuple<int, int>> _rowColumnIncrements = new Dictionary
            <Direction, Tuple<int, int>>
        {
            { Direction.Up, Tuple.Create(-1, 0) },
            { Direction.Left, Tuple.Create(0, -1) },
            { Direction.Down, Tuple.Create(1, 0) },
            { Direction.Right, Tuple.Create(0, 1) }
        };

        private readonly int _rows;
        private readonly int _columns;
        private readonly int[,] _matrix;

        public static int[] TraverseCounterClockwise(int rows, int columns, int row, int column)
        {
            var traverser = new MatrixTraverser(rows, columns);
            return traverser.TraverseFrom(row - 1, column - 1);
        }

        private MatrixTraverser(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _matrix = BuildMatrix(rows, columns);
        }

        private static int[,] BuildMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            int idx = 1;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = idx++;
            return matrix;
        }

        public int[] TraverseFrom(int row, int col)
        {
            var path = new List<int>(_rows * _columns);
            int steps = 1;
            var position = Tuple.Create(row, col);
            var direction = Direction.Up;

            while (path.Count < _matrix.Length)
            {
                position = TraversePath(path, position.Item1, position.Item2, direction, steps);
                direction = _nextDirection[direction];
                if (direction == Direction.Down || direction == Direction.Up)
                    steps++;
            }
            return path.ToArray();
        }

        private Tuple<int, int> TraversePath(List<int> path, int row, int col, Direction direction, int steps)
        {
            var increments = _rowColumnIncrements[direction];
            int currentRow = row;
            int currentCol = col;
            for (int i = 0; i < steps; i++)
            {
                if (CellExistsInMatrix(currentRow, currentCol))
                    path.Add(_matrix[currentRow, currentCol]);
                currentRow += increments.Item1;
                currentCol += increments.Item2;
            }
            return Tuple.Create(currentRow, currentCol);
        }

        private bool CellExistsInMatrix(int row, int col)
        {
            if (row < 0 || row >= _rows)
                return false;
            if (col < 0 || col >= _columns)
                return false;
            return true;
        }
    }
}
