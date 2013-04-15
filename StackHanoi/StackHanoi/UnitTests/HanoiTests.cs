using NUnit.Framework;

namespace StackHanoi.UnitTests
{
    [TestFixture]
    public class HanoiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Move_One_Ring_To_End_Recursive()
        {
            var moves = Hanoi.SolveRecursive(1);
            Assert.That(moves, Has.Count.EqualTo(1));
            AssertMove(moves[0], Tower.One, Tower.Three);
        }

        [Test]
        public void Move_Two_Rings_To_End_Recursive()
        {
            var moves = Hanoi.SolveRecursive(2);
            Assert.That(moves, Has.Count.EqualTo(3));
            AssertMove(moves[0], Tower.One, Tower.Two);
            AssertMove(moves[1], Tower.One, Tower.Three);
            AssertMove(moves[2], Tower.Two, Tower.Three);
        }

        [Test]
        public void Move_Three_Rings_To_End_Recursive()
        {
            var moves = Hanoi.SolveRecursive(3);
            Assert.That(moves, Has.Count.EqualTo(7));
            AssertMove(moves[0], Tower.One, Tower.Three);
            AssertMove(moves[1], Tower.One, Tower.Two);
            AssertMove(moves[2], Tower.Three, Tower.Two);
            AssertMove(moves[3], Tower.One, Tower.Three);
            AssertMove(moves[4], Tower.Two, Tower.One);
            AssertMove(moves[5], Tower.Two, Tower.Three);
            AssertMove(moves[6], Tower.One, Tower.Three);
        }

        [Test]
        public void Move_One_Ring_To_End_Stack()
        {
            var moves = Hanoi.SolveStack(1);
            Assert.That(moves, Has.Count.EqualTo(1));
            AssertMove(moves[0], Tower.One, Tower.Three);
        }

        [Test]
        public void Move_Two_Rings_To_End_Stack()
        {
            var moves = Hanoi.SolveStack(2);
            Assert.That(moves, Has.Count.EqualTo(3));
            AssertMove(moves[0], Tower.One, Tower.Two);
            AssertMove(moves[1], Tower.One, Tower.Three);
            AssertMove(moves[2], Tower.Two, Tower.Three);
        }

        [Test]
        public void Move_Three_Rings_To_End_Stack()
        {
            var moves = Hanoi.SolveStack(3);
            Assert.That(moves, Has.Count.EqualTo(7));
            AssertMove(moves[0], Tower.One, Tower.Three);
            AssertMove(moves[1], Tower.One, Tower.Two);
            AssertMove(moves[2], Tower.Three, Tower.Two);
            AssertMove(moves[3], Tower.One, Tower.Three);
            AssertMove(moves[4], Tower.Two, Tower.One);
            AssertMove(moves[5], Tower.Two, Tower.Three);
            AssertMove(moves[6], Tower.One, Tower.Three);
        }

        private void AssertMove(Move move, Tower fromTower, Tower toTower)
        {
            Assert.That(move.From, Is.EqualTo(fromTower));
            Assert.That(move.To, Is.EqualTo(toTower));
        }
    }
}
