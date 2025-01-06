using System.Collections;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>, IExpandable
    {
        private T[] _data;
        private int _count;
        
        public event Action? OnExpandedEvent;
        public CustomList()
        {
            _data = new T[4];
            _count = 0;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("Index is out of range.");
                return _data[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("Index is out of range.");
                _data[index] = value;
            }
        }
        public void Add(T element)
        {
            if (_count == _data.Length)
            {
                ExpandArray();
                OnExpandedEvent?.Invoke();
            }

            _data[_count] = element;
            _count++;
        }
        private void ExpandArray()
        {
            T[] newArray = new T[_data.Length * 2];
            Array.Copy(_data, newArray, _data.Length);
            _data = newArray;
        }
        public int Count => _count;
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _data[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}