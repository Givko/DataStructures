namespace _01.LinearDS
{
    internal class ArrayList<T>
    {
        private T[] _items;

        public ArrayList() => _items = new T[4];
        public ArrayList(int initialCapacity) => _items = new T[initialCapacity];

        public int Count { get; private set; }

        public T this[int index] { get => _items[index]; set => Add(value); }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Count + 1 >= _items.Length)
            {
                T[] curItems = _items;
                _items = new T[curItems.Length * 2];

                Array.Copy(curItems, _items, curItems.Length);
            }

            _items[Count++] = item;
        }
    }
}