using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace JavaCompiler.Utilities
{
    [Serializable]
    public class StackList<T> : ICollection<T>, ICollection
    {
        protected T[] array;
        protected int version;

        [NonSerialized]
        private object syncRoot;

        private static readonly T[] EmptyArray = new T[0];

        public struct Enumerator : IEnumerator<T>
        {
            private readonly StackList<T> stack;
            private readonly int version;

            private int index;
            private T currentElement;

            public T Current
            {
                get
                {
                    if (index == -2)
                    {
                        throw new InvalidOperationException();
                    }
                    if (index == -1)
                    {
                        throw new InvalidOperationException();
                    }
                    return currentElement;
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    if (index == -2)
                    {
                        throw new InvalidOperationException();
                    }
                    if (index == -1)
                    {
                        throw new InvalidOperationException();
                    }
                    return currentElement;
                }
            }

            internal Enumerator(StackList<T> stack)
            {
                this.stack = stack;
                version = this.stack.version;
                index = -2;
                currentElement = default(T);
            }

            public void Dispose()
            {
                index = -1;
            }

            public bool MoveNext()
            {
                if (version != stack.version)
                {
                    throw new InvalidOperationException();
                }
                bool flag;
                if (index == -2)
                {
                    index = stack.Count - 1;
                    flag = (index >= 0);
                    if (flag)
                    {
                        currentElement = stack.array[index];
                    }
                    return flag;
                }
                if (index == -1)
                {
                    return false;
                }
                flag = (--index >= 0);

                currentElement = flag ? stack.array[index] : default(T);

                return flag;
            }

            void IEnumerator.Reset()
            {
                if (this.version != this.stack.version)
                {
                    throw new InvalidOperationException();
                }
                this.index = -2;
                this.currentElement = default(T);
            }
        }

        public StackList()
        {
            array = EmptyArray;
            Count = 0;
            version = 0;
        }
        public StackList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacitiy must be non-negative", "capacity");
            }

            array = new T[capacity];
            Count = 0;
            version = 0;
        }
        public StackList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentException("collection must not be null", "collection");
            }

            var collection2 = collection as ICollection<T>;
            if (collection2 != null)
            {
                var count = collection2.Count;

                array = new T[count];
                collection2.CopyTo(array, 0);

                Count = count;
            }
            else
            {
                Count = 0;
                array = new T[4];

                using (var enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Push(enumerator.Current);
                    }
                }
            }
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return array[Count - 1];
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            version++;

            var result = array[--Count];
            array[Count] = default(T);

            return result;
        }
        public virtual void Push(T item)
        {
            if (Count == array.Length)
            {
                var newArray = new T[(array.Length == 0) ? 4 : (2 * array.Length)];
                Array.Copy(array, 0, newArray, 0, Count);

                array = newArray;
            }

            array[Count++] = item;
            version++;
        }

        public void Clear()
        {
            Array.Clear(array, 0, Count);

            Count = 0;
            version++;
        }

        public bool Contains(T item)
        {
            var size = Count;

            var @default = EqualityComparer<T>.Default;
            while (size-- > 0)
            {
                if ((object)item == null)
                {
                    if ((object)array[size] == null)
                    {
                        return true;
                    }
                }
                else
                {
                    if ((object)array[size] != null && @default.Equals(array[size], item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(Array newArray, int arrayIndex)
        {
            if (newArray.Rank != 1)
            {
                throw new ArgumentException("Multidimesional arrays are not supported", "newArray");
            }
            if (newArray.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Non-zero lower bound", "newArray");
            }
            if (arrayIndex < 0 || arrayIndex > newArray.Length)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }
            if (newArray.Length - arrayIndex < Count)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }

            Array.Copy(array, 0, newArray, arrayIndex, Count);
            Array.Reverse(newArray, arrayIndex, Count);
        }
        public void CopyTo(T[] newArray, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > newArray.Length)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }
            if (newArray.Length - arrayIndex < Count)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }

            Array.Copy(array, 0, newArray, arrayIndex, Count);
            Array.Reverse(newArray, arrayIndex, Count);
        }

        public void Add(T item)
        {
            throw new InvalidOperationException();
        }
        public bool Remove(T item)
        {
            throw new InvalidOperationException();
        }

        public T[] ToArray()
        {
            var newArray = new T[Count];
            for (var i = 0; i < Count; i++)
            {
                newArray[i] = array[Count - i - 1];
            }
            return newArray;
        }
        public void TrimExcess()
        {
            var num = (int)(array.Length * 0.9);
            if (Count >= num) return;

            var newArray = new T[Count];
            Array.Copy(array, 0, newArray, 0, Count);

            array = newArray;
            version++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; protected set; }

        public object SyncRoot
        {
            get
            {
                if (syncRoot == null)
                {
                    Interlocked.CompareExchange<object>(ref syncRoot, new object(), null);
                }
                return syncRoot;
            }
        }
        public bool IsSynchronized { get { return false; } }
        public bool IsReadOnly { get { return false; } }

        public T this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }
    }
}
