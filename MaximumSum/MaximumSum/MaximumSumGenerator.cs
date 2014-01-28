using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumSum
{
    public class MaximumSumGenerator
    {
        public static int[] GetContiguousMax(params int[] numbers)
        {
            var sequences = new List<Tuple<int, IList<int>>>();
            for (int i = 0, j = numbers.Length; i < j; i++, j--)
                sequences.AddRange(GetAllSequences(numbers.Skip(i).Take(j).ToList()));

            return GetLargestSequence(numbers, sequences).ToArray();
        }

        private static IEnumerable<Tuple<int, IList<int>>> GetAllSequences(IList<int> numbers)
        {
            var sequences = new List<Tuple<int, IList<int>>>();
            for (int i = 0; i < numbers.Count; i++)
            {
                IList<int> list = numbers.Skip(i).ToList();
                sequences.Add(Tuple.Create(list.Sum(), list));
            }
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                IList<int> list = numbers.Take(i).ToArray();
                sequences.Add(Tuple.Create(list.Sum(), list));
            }
            return sequences;
        }

        private static IEnumerable<int> GetLargestSequence(int[] numbers, IEnumerable<Tuple<int, IList<int>>> sequences)
        {
            var largestSequence = Tuple.Create(numbers.Sum(), (IList<int>)numbers);
            foreach (var seq in sequences)
            {
                if (seq.Item1 > largestSequence.Item1)
                    largestSequence = seq;
            }
            return largestSequence.Item2;
        }
    }
}
