using System;
using NUnit.Framework;

namespace StackHanoi.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Popping_Empty_Stack_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void Peeking_Empty_Stack_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Test]
        public void Can_Pop_The_Stack_With_Items_On_It()
        {
            _stack.Push("funky");
            Assert.That(_stack.Pop(), Is.EqualTo("funky"));
        }

        [Test]
        public void Popping_The_Stack_Removes_The_Item()
        {
            _stack.Push("duder");
            _stack.Pop();
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void Can_Peek_The_Stack_With_Items_On_It()
        {
            _stack.Push("funky");
            Assert.That(_stack.Peek(), Is.EqualTo("funky"));
        }

        [Test]
        public void Peeking_The_Stack_Leaves_The_Item()
        {
            _stack.Push("duder");
            _stack.Peek();
            Assert.DoesNotThrow(() => _stack.Pop());
        }
    }
}
