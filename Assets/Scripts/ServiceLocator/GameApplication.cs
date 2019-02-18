using Common;
using UnityEngine;
using Player;
using Enemy;
using System.Collections.Generic;
using GameplayInterfaces;
namespace ServiceLocator
{
    public class GameApplication : SingletonBase<GameApplication>
    {
        private List<IService> listOfServices = new List<IService>();
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Register<IPlayerService>(new PlayerService());
        }

        public void Register<T>(T _service) where T : IService
        {
            listOfServices.Add(_service);
            Debug.Log(" Register Service:"+ _service.ToString());
        }
        
        public void DeRegister<T>(T _service) where T : IService
        {
            listOfServices.Remove(_service);
        }

        public T GetService<T>() where T : IService
        {
            T _serviceToReturn = default(T);
            if (listOfServices.Contains(_serviceToReturn))
            {

                return _serviceToReturn;
            }
            else
            {
                Register<T>(_serviceToReturn);
                return _serviceToReturn;
            }
        }
    }
}