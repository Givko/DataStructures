using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.BinarySearchTreeAndHeaps
{
    //Parent(i) = (i - 1) / 2
    //Left(i) = 2 * i + 1;
    //Right(i) = 2 * i + 2

    public class MaxHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements = new List<T>();

        public void Add(T element)
        {
            _elements.Add(element);
            Heapify(_elements.Count-1);
        }

        private void Heapify(int index)
        {
            var parentIndex = (index - 1) / 2;
            while(index > 0 && IsGreater(index, parentIndex))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        public void Print()
        {
            if (_elements is null || _elements.Count == 0)
            {
                Console.WriteLine("No nodes in tree");
            }

            PrintInternal(0);
        }

        private bool IsGreater(int index, int toCompareTo)
            => _elements[index].CompareTo(_elements[toCompareTo]) > 0;

        private void PrintInternal(int index, int indentation = 0)
        {
            if ((index*2+1) < _elements.Count)
            {
                PrintInternal((index * 2 + 1), indentation + 5);
            }

            Console.WriteLine(new string(' ', indentation) + _elements[index]);
            Console.WriteLine();

            if ((index * 2 + 2) < _elements.Count)
            {
                PrintInternal((index * 2 + 2), indentation + 5);
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = _elements[index2];
            _elements[index2] = _elements[index1];
            _elements[index1] = temp;
        }
    }
}
