using NUnit.Framework;

namespace MaximumSum.UnitTests
{
    [TestFixture]
    public class MaximumSumGeneratorTests
    {
        [Test]
        public void One_number_is_returned()
        {
            AssertMaxSum(new[] { 1 }, new[] { 1 });
        }

        [Test]
        public void Multiple_positive_numbers_are_returned()
        {
            AssertMaxSum(new[] { 1, 2, 3 }, new[] { 1, 2, 3 });
        }

        [Test]
        public void One_negative_is_excluded()
        {
            AssertMaxSum(new[] { -1, 1, 1 }, new[] { 1, 1 });
        }

        [Test]
        public void Positive_excluded_when_not_adding_to_best_sum()
        {
            AssertMaxSum(new[] { 1, 1, -2, 1 }, new[] { 1, 1 });
        }

        [Test]
        public void Negative_prefix_excluded_from_best_sum()
        {
            AssertMaxSum(new[] { -1, 1, 1, -2, 1 }, new[] { 1, 1 });
        }

        [Test]
        public void Negative_numbers_included_when_bigger_sum_results()
        {
            AssertMaxSum(new[] { -1, 1, 2, 3, -1, 3, -5 }, new[] { 1, 2, 3, -1, 3 });
        }

        [Test]
        public void Original_problem_test_to_prove_this_works()
        {
            AssertMaxSum(new[] { -1, 5, 6, -2, 20, -50, 4 }, new[] { 5, 6, -2, 20 });
        }

        private void AssertMaxSum(int[] input, int[] expected)
        {
            Assert.That(MaximumSumGenerator.GetContiguousMax(input), Is.EqualTo(expected));
        }
    }
}
