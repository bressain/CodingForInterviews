using NUnit.Framework;

namespace SpiralMatrixTraversal.UnitTests
{
    [TestFixture]
    public class MatrixTraverserTests
    {
        [Test]
        public void One_cell_returns_single_path_number()
        {
            // 1*
            AssertTraversal(1, 1, 1, 1, 1);
        }

        [Test]
        public void Path_starts_with_initial_and_does_next_spot_with_two_cells()
        {
            // 1
            // 2*
            AssertTraversal(2, 1, 2, 1, 2, 1);
        }

        [Test]
        public void Path_goes_left_after_going_up()
        {
            // 1 2
            // 3 4*
            AssertTraversal(2, 2, 2, 2, 4, 2, 1, 3);
        }

        [Test]
        public void Path_keeps_going_around_until_out_of_numbers()
        {
            //  1  2  3  4  5
            //  6  7  8  9 10
            // 11 12 13*14 15
            // 16 17 18 19 20
            // 21 22 23 24 25
            AssertTraversal(5, 5, 3, 3, 13, 8, 7, 12, 17, 18, 19, 14, 9, 4, 3, 2, 1, 6, 11, 16, 21, 22, 23, 24, 25, 20, 15,
                10, 5);
        }

        [Test]
        public void Paths_are_skipped_when_past_rectangular_boundaries()
        {
            // 1 2*3 4
            // 5 6 7 8
            AssertTraversal(2, 4, 1, 2, 2, 1, 5, 6, 7, 3, 8, 4);
        }

        [Test]
        public void Paths_can_start_on_the_corner()
        {
            // 1 2 3
            // 4 5 6
            // 7 8 9*
            AssertTraversal(3, 3, 3, 3, 9, 6, 5, 8, 3, 2, 1, 4, 7);
        }

        private void AssertTraversal(int rows, int cols, int row, int col, params int[] expected)
        {
            Assert.That(MatrixTraverser.TraverseCounterClockwise(rows, cols, row, col), Is.EqualTo(expected));
        }
    }
}
