using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.Advanced.BAndRedAndBlackTrees
{
    public class RedAndBlackTree<T>
        where T : IComparable<T>
    {
        private const bool Red = true;
        private const bool Black = false;
        private Node<T>? _root;

        public RedAndBlackTree(T root)
        {
            if (root is null) throw new ArgumentNullException(nameof(root));

            _root = new Node<T>(root);
        }

        public RedAndBlackTree() { }

        public void Add(T value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            if (_root is null)
            {
                _root = new Node<T>(value);
                _root.Color = Black;
                return;
            }

            _root = AddInternal(value, _root!);
            _root.Color = Black;
            Print();
        }

        private Node<T> AddInternal(T value, Node<T> currentNode)
        {
            if (currentNode is null)
            {
                return new Node<T>(value);
            }
            else if (value!.CompareTo(currentNode.Value) > 0)
            {
                currentNode.RightChild = AddInternal(value, currentNode.RightChild);
            }
            else if(value!.CompareTo(currentNode.Value) < 0)
            {
                currentNode.LeftChild = AddInternal(value, currentNode.LeftChild);
            }

            if (IsRed(currentNode.RightChild) && !IsRed(currentNode.LeftChild))
                currentNode = RotateLeft(currentNode);
            if (IsRed(currentNode.LeftChild) && IsRed(currentNode.LeftChild.LeftChild))
                currentNode = RotateRight(currentNode);
            if (IsRed(currentNode.LeftChild) && IsRed(currentNode.RightChild))
                FlipColors(currentNode);

            return currentNode;
        }

        private void FlipColors(Node<T> node)
        {
            node.Color = Red;
            if (node.LeftChild is not null)
                node.LeftChild.Color = Black;
            if (node.RightChild is not null)
                node.RightChild.Color = Black;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> temp = node.RightChild;
            node.RightChild = temp.LeftChild;
            temp.LeftChild = node;
            temp.Color = node.Color;
            node.Color = Red;

            return temp;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> temp = node.LeftChild;
            node.LeftChild = temp.RightChild;
            temp.RightChild = node;
            temp.Color = node.Color;
            node.Color = Red;

            return temp;
        }

        private bool IsRed(Node<T> node) => node?.Color == Red;

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

            Console.ForegroundColor = curNode.Color == Red ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(new string(' ', indentation) + curNode.Value, Black);
            if (curNode.RightChild is not null)
            {
                PrintInternal(curNode.RightChild, indentation + 5);
            }
        }

        private class Node<N>
            where N : IComparable<N>
        {
            public N Value { get; private set; }

            public Node<N>? LeftChild { get; set; }

            public Node<N>? RightChild { get; set; }

            public bool Color { get; set; }

            public Node(
                N value,
                Node<N>? leftChild = default,
                Node<N>? rightChild = default
            )
            {
                Value = value;
                LeftChild = leftChild;
                RightChild = rightChild;
                Color = Red;
            }
        }
    }
}