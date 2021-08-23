using System.Collections;
using System.Collections.Generic;
using niscolas.UnityExtensions;

namespace BestLostNFound
{
    public abstract class PluralDataWrapper<T>
    {
        public PluralDataWrapper()
        {
            Internal_Content = new List<T>();
        }

        public PluralDataWrapper(IEnumerable<T> content)
        {
            Internal_Content = content.AsList();
        }

        public PluralDataWrapper(params T[] content)
        {
            Internal_Content = content.AsList();
        }

        public virtual bool IsValid => Internal_Content.IsNotNullOrEmpty();

        public virtual int Count => Internal_Content.Count;

        protected virtual List<T> Internal_Content { get; set; }

        public void Add(T data)
        {
            Internal_Content.Add(data);
        }

        public void Join(PluralDataWrapper<T> other)
        {
            Internal_Content.AddRange(other.Internal_Content);
        }

        public void Clear()
        {
            Internal_Content.Clear();
        }
    }

    public abstract class EnumerablePluralDataWrapper<T> : PluralDataWrapper<T>, IEnumerable<T>
    {
        public EnumerablePluralDataWrapper() { }

        public EnumerablePluralDataWrapper(IEnumerable<T> content) : base(content) { }

        public EnumerablePluralDataWrapper(params T[] content) : base(content) { }

        public IEnumerator<T> GetEnumerator()
        {
            return Internal_Content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
