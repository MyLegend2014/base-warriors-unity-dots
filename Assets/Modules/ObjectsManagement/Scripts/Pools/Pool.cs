using System.Collections.Generic;
using UnityEngine;

namespace Modules.ObjectsManagement.Pools
{
    public class Pool<T> where T :Component
    {
        private readonly T _prefab;
        private readonly Transform _root;
        private readonly Queue<T> _objects = new();
        private readonly int _initialCapacity;

        public Pool(T prefab, Transform root)
        {
            _prefab = prefab;
            _root = root;
        }
        
        public Pool(T prefab, Transform root, int initialCapacity) : this(prefab, root)
        {
            _prefab = prefab;
            _initialCapacity = initialCapacity;
        }

        public void Initialize()
        {
            for (int i = 0; i < _initialCapacity; i++)
            {
                T newObject = Object.Instantiate(_prefab, _root);
                OnDespawned(newObject);
                _objects.Enqueue(newObject);
            }
        }

        public T Rent()
        {
            T newObject;
            
            if (_objects.TryDequeue(out newObject) == false)
                newObject = Object.Instantiate(_prefab, _root);

            OnSpawned(newObject);

            return newObject;
        }

        public void Return(T poolableObject)
        {
            OnDespawned(poolableObject);
            _objects.Enqueue(poolableObject);
        }

        protected virtual void OnDespawned(T poolableObject)
        {
            poolableObject.gameObject.SetActive(false);
        }

        protected virtual void OnSpawned(T poolableObject)
        {
            poolableObject.gameObject.SetActive(true);
        }
    }
}