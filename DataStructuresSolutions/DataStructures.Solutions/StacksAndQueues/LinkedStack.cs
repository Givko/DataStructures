using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.StacksAndQueues
{
    public class LinkedStack<T>
    {
        private Node<T> _firstNode;
        public int Count { get; private set; }

        public void Push(T element) 
        {
            if (_firstNode == default)
            {
                _firstNode = new Node<T>(element);
            }
            else
            {
                var newNode = new Node<T>(element, _firstNode);
                _firstNode = newNode;
            }

            Count++;
        }

        public T Pop() 
        {
            if (_firstNode == default)
            {
                throw new InvalidOperationException();
            }

            var firstNode = _firstNode;
            _firstNode = firstNode.NextNode;

            Count--;

            return firstNode.Value;
        }

        public T[] ToArray() 
        {
            var array = new List<T>();

            var currentNode = _firstNode;
            while (currentNode != default)
            {
                array.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }

            return array.ToArray();
        }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = default!) 
            {
                Value = value;
                NextNode = nextNode;
            }
        }
    }
}
