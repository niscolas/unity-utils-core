using System.Collections;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using UnityEngine;

namespace niscolas.UnityUtils.Core
{
    public abstract class ParentCollectionMB<TBase, TChild> : CachedMB, ICollection<TBase>
        where TChild : TBase
    {
        [SerializeField]
        protected List<TChild> _content = new List<TChild>();

        public int Count => _content.Count;

        public bool IsReadOnly => false;

        public IEnumerator<TBase> GetEnumerator()
        {
            return ((IEnumerable<TBase>) _content).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TBase item)
        {
            _content.AddParentItem(item);
        }

        public void Clear()
        {
            _content.Clear();
        }

        public bool Contains(TBase item)
        {
            return _content.ContainsParentItem(item);
        }

        public void CopyTo(TBase[] array, int arrayIndex)
        {
            _content.CopyToParentArray(array, arrayIndex);
        }

        public bool Remove(TBase item)
        {
            return _content.RemoveParentItem(item);
        }
    }
}