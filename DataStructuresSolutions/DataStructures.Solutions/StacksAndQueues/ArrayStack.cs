using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.StacksAndQueues
{
    public class ArrayStack<T>
    {
        private T[] _elements;

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ArrayStack(int capacity = 16)
        {
            Count = 0;
            Capacity = capacity;
            _elements = new T[Capacity];
        }

        public void Push(T element)
        {
            if (Count == _elements.Length)
            {
                Resize(Capacity * 2);
            }

            _elements[Count] = element;
            Count++;
        }

        public T? Pop() 
        {
            if (Count == 0)
            {
                return default;
            }

            var element = _elements[Count - 1];
            _elements[Count - 1] = default!;
            Count -= 1;

            if (Count == Capacity / 4)
            {
                Resize(Capacity / 4);
            }

            return element;
        }

        public T[] ToArray() 
        {
            var array = new T[Count];
            Array.Copy(_elements, array, Count);

            return array;

        }

        private void Resize(int size) 
        {
            T[] oldArray = _elements;
            _elements = new T[size];
            Array.Copy(oldArray, _elements, Count);
            Capacity = size;
        }
    }
}