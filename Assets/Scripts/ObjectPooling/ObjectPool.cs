using System;
using UnityEngine;
using System.Collections.Generic;

namespace ObjectPooling
{
    public class ObjectPool<T> where T : IPoolable, new()
    {
        private int upperLimit = 50;
        private List<IPoolable> objectPool = new List<IPoolable>();
        public T Get<T>() where T : IPoolable, new()
        {
            T _itemToReturn = default(T);
            foreach (T item in objectPool)
            {
                if (item is T)
                {
                    Debug.Log("Object found in list :"+objectPool.Count);
                    objectPool.Remove(item);
                    _itemToReturn = item;
                    break;
                }
            }
            if (_itemToReturn == null)
            {
                Debug.Log("Object not found in list"+objectPool.Count);
                _itemToReturn = new T();
                objectPool.Add(_itemToReturn);
            }

            return _itemToReturn;


        }
        public void ReturnToPool(T obj)
        {
            Debug.Log("Object returning in list :"+objectPool.Count);
            objectPool.Add(obj);
        }

    }
}