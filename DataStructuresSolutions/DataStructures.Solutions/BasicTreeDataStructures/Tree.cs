using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.BasicTreeDataStructures
{
    public class Tree<T>
    {
        private Node<T>? _root;

        public Tree(T root)
        {
            if (root is null) throw new ArgumentNullException(nameof(root));

            _root = new Node<T>(root);
        }

        public Tree()
        {

        }

        public void AddChildTo(T valueToAddTo, T childValueToAdd)
        {
            if (valueToAddTo is null || childValueToAdd is null)
            {
                throw new ArgumentNullException($"{nameof(valueToAddTo)} or {nameof(childValueToAdd)} is null");
            }

            if (_root is null)
            {
                _root = new Node<T>(valueToAddTo);
                _root.Children.Add(new Node<T>(childValueToAdd));
                return;
            }

            AddChildToInternal(valueToAddTo, childValueToAdd, _root);
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

            PrintMiddleNodesInternal(_root!.Children);
        }

        private void PrintMiddleNodesInternal(List<Node<T>> rootChildNodes)
        {
            foreach (var childNode in rootChildNodes)
            {
                PrintMiddleNodesInternal(childNode.Children!);
                if (childNode.Children is null || childNode.Children!.Count == 0)
                    continue;

                Console.WriteLine(childNode.Value);
            }
        }

        private void PrintLeafNodesInternal(Node<T> curNode)
        {
            if (curNode.Children is null || curNode.Children.Count == 0)
            {
                Console.WriteLine(curNode.Value);
            }

            foreach (var childNode in curNode.Children!)
                PrintLeafNodesInternal(childNode);
        }

        private void PrintInternal(Node<T> curNode, int indentation = 0)
        {
            Console.WriteLine(new string(' ', indentation) + curNode.Value);
            foreach (var child in curNode.Children)
                PrintInternal(child, indentation + 3);
        }

        private void AddChildToInternal(T valueToAddTo, T childValueToAdd, Node<T> currentNode)
        {
            if (currentNode.Value!.Equals(valueToAddTo))
            {
                currentNode.Children.Add(new Node<T>(childValueToAdd));
            }

            foreach (var child in currentNode.Children)
                AddChildToInternal(valueToAddTo, childValueToAdd, child);
        }

        private class Node<N>
        {
            public N Value { get; private set; }

            public List<Node<N>> Children { get; set; }

            public Node(N value, params Node<N>[] children)
            {
                Value = value;
                Children = children.ToList();
            }
        }
    }
}
