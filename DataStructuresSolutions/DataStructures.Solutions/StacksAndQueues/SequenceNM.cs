using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.StacksAndQueues
{
    public static class SequenceNM
    {
        //a) n  n + 1
        //b) n  n + 2
        //c) n  n* 2

        public static IEnumerable<int> FindShortestPath(int n, int m)
        {
            if (n > m)
            {
                return Enumerable.Empty<int>();
            }

            var queue = new Queue<Node<int>>();
            queue.Enqueue(new Node<int>(n, null));
            while (queue.Count > 0)
            {
                var curItem = queue.Dequeue();
                queue.Enqueue(new Node<int>(curItem.Value + 1, curItem));
                queue.Enqueue(new Node<int>(curItem.Value + 2, curItem));
                queue.Enqueue(new Node<int>(curItem.Value * 2, curItem));
                if (curItem.Value == m)
                {
                    var stackResult = new Stack<int>();
                    while (curItem != default)
                    {
                        stackResult.Push(curItem.Value);
                        curItem = curItem.PreviousNode;
                    }

                    return stackResult;
                }
            }

            return Enumerable.Empty<int>();
        }

        private class Node<T>
        {
            public T Value { get; private set; }

            public Node<T> PreviousNode { get; private set; }

            public Node(T value, Node<T>? previousValue)
            {
                Value = value;
                PreviousNode = previousValue;
            }
        }
    }
}
