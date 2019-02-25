using System;
using System.Collections.Generic;
using ServiceLocator;
using GameplayInterfaces;
using UnityEngine;

namespace ObjectPooling
{
    public class ObjectPool<T> where T : IPoolable, new()
    {
        private int upperLimit = 50;
        private List<IPoolable> objectPool = new List<IPoolable>();

        public void ObjectPoolStart()
        {
            GameApplication.Instance.GetService<IStateMachineService>().OnEnterGameOverScene += OnGameOver;
        }
        
        public T Get<T>() where T : IPoolable, new()
        {
            T _itemToReturn = default(T);
            foreach (T item in objectPool)
            {
                if (item is T)
                {                    
                    objectPool.Remove(item);
                    _itemToReturn = item;
                    break;
                }
            }
            if (_itemToReturn == null)
            {
               
                _itemToReturn = new T();

                objectPool.Add(_itemToReturn);
            }

            return _itemToReturn;


        }
        public void ReturnToPool(T obj)
        {
            Debug.Log("Object returning in list :" + objectPool.Count);
            if (objectPool.Count >= upperLimit)
            {
                return;
            }
            objectPool.Add(obj);
        }

        public void OnGameOver()
        {
            foreach (IPoolable item in objectPool)
            {
                item.Reset();
            }
        }
    }
}
