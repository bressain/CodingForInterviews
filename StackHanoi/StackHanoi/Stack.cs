using System;
using System.Collections.Generic;

namespace StackHanoi
{
    public class Stack<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public void Push(T value)
        {
            _list.AddLast(value);
        }

        public T Pop()
        {
            var last = _list.Last;
            _list.RemoveLast();
            return last.Value;
        }

        public T Peek()
        {
            if (_list.Last == null)
                throw new InvalidOperationException("Can't peek the stack when empty");
            return _list.Last.Value;
        }
    }
}
