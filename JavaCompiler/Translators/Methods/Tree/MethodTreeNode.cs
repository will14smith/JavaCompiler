using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JavaCompiler.Reflection;

namespace JavaCompiler.Translators.Methods.Tree
{
    public abstract class MethodTreeNode
    {
        public Type ReturnType { get; set; }

        public abstract void ValidateType();
    }
    public abstract class MethodTreeNode<T> : MethodTreeNode, IList<T> where T : MethodTreeNode
    {
        private readonly List<T> backend = new List<T>();

        public override void ValidateType()
        {
            foreach(var item in backend)
            {
                item.ValidateType();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return backend.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return backend.GetEnumerator();
        }

        public void Add(T item)
        {
            backend.Add(item);
        }

        public void Clear()
        {
            backend.Clear();
        }

        public bool Contains(T item)
        {
            return backend.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            backend.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return backend.Remove(item);
        }

        public int Count { get { return backend.Count; } }
        public bool IsReadOnly { get { return false; } }

        public int IndexOf(T item)
        {
            return backend.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            backend.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            backend.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return backend[index]; }
            set { backend[index] = value; }
        }

        public override string ToString()
        {
            return backend.Aggregate("", (current, item) => current + (item.ToString() + "; "));
        }
    }

    public class MethodTree : MethodTreeNode<MethodTreeNode>
    {
    }
}
