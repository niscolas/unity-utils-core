using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Core
{
    public class LinearLayoutGroup3D : CachedMonoBehaviour
    {
        [Required]
        [SerializeField]
        private Transform _startPoint;

        [Required]
        [SerializeField]
        private Transform _endPoint;

        [SerializeField]
        private Transform _itemsParent;

        [SerializeField]
        private bool _destroyOnRemoval;

        [Header("Events")]
        [SerializeField]
        private UnityEvent<GameObject> _elementRemoved;

        public readonly List<Transform> Items = new List<Transform>();

        public Transform ItemsParent => _itemsParent;

        protected override void Awake()
        {
            base.Awake();

            if (_itemsParent != null)
            {
                return;
            }

            _itemsParent = new GameObject("ItemsContainer").transform;
            _itemsParent.SetParent(transform);
        }

        public void AddItem(Transform item)
        {
            if (item == null)
            {
                return;
            }

            Items.Add(item);
            item.SetParent(_itemsParent);

            RearrangeItems();
        }

        public void RemoveItem(Transform item)
        {
            if (item == null)
            {
                return;
            }

            Items.Remove(item);

            RearrangeItems();
        }

        public void ReplaceAt(int index, Transform newItem)
        {
            if (index.IsValidIndex(Items.Count))
            {
                Replace(Items[index], newItem);
            }
        }

        public void Replace(Transform currentItem, Transform newItem)
        {
            Items.Replace(currentItem, newItem);

            newItem.SetParent(_itemsParent);
            newItem.transform.position = currentItem.position;

            Destroy(currentItem.gameObject);
        }

        public void RemoveLast()
        {
            RemoveAt(Items.Count - 1);
        }

        public void RemoveAt(int index)
        {
            if (!index.IsValidIndex(Items.Count))
            {
                return;
            }

            Transform itemToRemove = Items[index];

            Remove(itemToRemove);
        }

        public void Remove(Transform item)
        {
            if (!item)
            {
                return;
            }

            Items.Remove(item);

            if (_destroyOnRemoval)
            {
                Destroy(item.gameObject);
            }
            else
            {
                item.gameObject.SetActive(false);
            }

            RearrangeItems();
        }

        public void RemoveAll()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                RemoveAt(0);
            }
        }

        private void RearrangeItems()
        {
            Vector3[] itemsPositions = _startPoint.position.GetPointsBetween(_endPoint.position, Items.Count);
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].position = itemsPositions[i];
            }
        }

        public void ClearItems()
        {
            Items.Clear();

            _itemsParent.DestroyChildren();
        }
    }
}