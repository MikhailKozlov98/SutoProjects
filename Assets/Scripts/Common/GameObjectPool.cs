using System.Collections.Generic;
using UnityEngine;

    public sealed class GameObjectPool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _pool = new();
        private T _prefab;

        public GameObjectPool(T prefab)
        {
            _prefab = prefab;
        }

        public T Create(Transform parent)
        {
            if (_pool.TryDequeue(out var obj))
            {
                obj.transform.SetParent(parent);
            }
            else
            {
                obj = Object.Instantiate(this._prefab, parent);
            }
            return obj;
        }

        public void Despawn(T item, Transform parent)
        {
            item.transform.SetParent(parent);
            _pool.Enqueue(item);
        }
    }
