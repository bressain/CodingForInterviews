using System.Collections.Generic;

namespace StackHanoi
{
    public class Hanoi
    {
        private static IList<Move> _moves;

        public static IList<Move> SolveStack(int rings)
        {
            InitializeMoves();
            var stack = CreateInitialStack(rings);
            while (stack.Peek() != null)
                IterateStack(stack);
            return _moves;
        }

        private static void IterateStack(Stack<MoveArgs> stack)
        {
            var args = stack.Pop();
            if (args.Rings == 1)
            {
                _moves.Add(new Move(args.From, args.To));
                return;
            }
            stack.Push(new MoveArgs { Rings = args.Rings - 1, From = args.Via, To = args.To, Via = args.From });
            stack.Push(new MoveArgs { Rings = 1, From = args.From, To = args.To, Via = args.Via });
            stack.Push(new MoveArgs { Rings = args.Rings - 1, From = args.From, To = args.Via, Via = args.To });
        }

        private static void InitializeMoves()
        {
            _moves = new List<Move>();
        }

        private static Stack<MoveArgs> CreateInitialStack(int rings)
        {
            var stack = new Stack<MoveArgs>();
            stack.Push(null);
            stack.Push(new MoveArgs { Rings = rings, From = Tower.One, To = Tower.Three, Via = Tower.Two });
            return stack;
        }

        public static IList<Move> SolveRecursive(int rings)
        {
            InitializeMoves();
            Move(new MoveArgs { Rings = rings, From = Tower.One, To = Tower.Three, Via = Tower.Two });
            return _moves;
        }

        private static void Move(MoveArgs args)
        {
            if (args.Rings == 1)
            {
                _moves.Add(new Move(args.From, args.To));
                return;
            }
            Move(new MoveArgs { Rings = args.Rings - 1, From = args.From, To = args.Via, Via = args.To });
            Move(new MoveArgs { Rings = 1, From = args.From, To = args.To, Via = args.Via });
            Move(new MoveArgs { Rings = args.Rings - 1, From = args.Via, To = args.To, Via = args.From });
        }

        private class MoveArgs
        {
            public int Rings { get; set; }
            public Tower From { get; set; }
            public Tower To { get; set; }
            public Tower Via { get; set; }
        }
    }
}
