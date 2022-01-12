using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.BinarySearchTreeAndHeaps
{
    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T>? _root;

        public BinarySearchTree(T root)
        {
            if (root is null) throw new ArgumentNullException(nameof(root));

            _root = new Node<T>(root);
        }
        public BinarySearchTree()
        {

        }

        public void Add(T value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_root is null)
            {
                _root = new Node<T>(value);
                return;
            }

            AddInternal(value, _root!);
        }

        public void PrintRoot()
        {
            if (_root is null)
            {
                Console.WriteLine("no nodes in tree");
            }

            Console.WriteLine(_root!.Value);
        }

        public void PrintLeafNodes()
        {
            if (_root is null)
            {
                Console.WriteLine("no nodes in tree");
            }

            PrintLeafNodesInternal(_root!);
        }

        public void Print()
        {
            if (_root is null)
            {
                Console.WriteLine("No nodes in tree");
            }

            PrintInternal(_root!);
        }

        public void PrintMiddleNodes()
        {
            if (_root is null)
            {
                Console.WriteLine("No nodes in tree");
            }

            PrintMiddleNodesInternal(_root!);
        }

        private void PrintMiddleNodesInternal(Node<T> curNode)
        {

            PrintMiddleNodesInternal(curNode.LeftChild!);
            PrintMiddleNodesInternal(curNode.RightChild!);
            if (curNode.LeftChild is null && curNode.RightChild is null)
                return;

            Console.WriteLine(curNode.Value);
        }

        private void PrintLeafNodesInternal(Node<T> curNode)
        {
            if (curNode.LeftChild is null && curNode.RightChild is null)
            {
                Console.WriteLine(curNode.Value);
                return;
            }

            PrintLeafNodesInternal(curNode.LeftChild!);
            PrintLeafNodesInternal(curNode.RightChild!);
        }

        private void PrintInternal(Node<T> curNode, int indentation = 0)
        {
            if (curNode.LeftChild is not null)
            {
                PrintInternal(curNode.LeftChild, indentation + 5);
            }

            Console.WriteLine(new string(' ', indentation) + curNode.Value);
            if (curNode.RightChild is not null)
            {
                PrintInternal(curNode.RightChild, indentation + 5);
            }
        }

        private void AddInternal(T value, Node<T> currentNode)
        {
            if (value!.CompareTo(currentNode.Value) >= 0)
            {
                if (currentNode.RightChild is null)
                {
                    currentNode.RightChild = new Node<T>(value);
                    return;
                }         
                else
                {
                    AddInternal(value, currentNode.RightChild);
                }
            }
            else
            {
                if (currentNode.LeftChild is null)
                {
                    currentNode.LeftChild = new Node<T>(value);
                    return;
                }
                else
                {
                    AddInternal(value, currentNode.LeftChild);
                }
            }
        }

        private class Node<N>
            where N : IComparable<N>
        {
            public N Value { get; private set; }

            public Node<N>? LeftChild { get; set; }
            public Node<N>? RightChild { get; set; }

            public Node(
                N value,
                Node<N>? leftChild = default,
                Node<N>? rightChild = default
            )
            {
                Value = value;
                LeftChild = leftChild;
                RightChild = rightChild;
            }
        }
    }
}
