using Common;
using ObjectPooling;
using AchievementSystem;
using ServiceLocator;
using System;
using UnityEngine;
using System.Collections.Generic;
using GameplayInterfaces;
using System.Linq;

namespace Enemy
{
    [System.Serializable]
    public struct EnemyData
    {
        public Vector3 spawnPosition;
        public int indexOfScriptableObj;

    }
    public class EnemyService : IEnemyService
    {
        private EnemyScriptableObjectList listOfEnemies;

        public List<EnemyData> enemyDataList = new List<EnemyData>();
        private List<EnemyController> spawnedEnemies = new List<EnemyController>();
        public event Action<int, EnemyType, int> EnemyDeath;
        public event Action<Vector3> PlayerSpotted;
        int currentDamagingID;
        private ObjectPool<EnemyController> objectPool;
        private GameObject enemyHolder;
        

        public EnemyService(EnemyScriptableObjectList _list)
        {
            listOfEnemies=_list;
        }
        public void OnStart()
        {
            if(!enemyHolder)
            {
                enemyHolder= new GameObject();
                enemyHolder.name= "Enemy Holder";
            }
            GameObject.DontDestroyOnLoad(enemyHolder);
            objectPool= new ObjectPool<EnemyController>();
            SpawnEnemyControllers();
            RegisterEvent();


        }
        public void OnUpdate()
        {
            
        }

        public void StopChasing()
        {
            foreach (EnemyController item in spawnedEnemies)
            {
                item.BackToPatrolling();
            }
        }

        private void RegisterEvent()
        {
            EnemyDeath += RemoveEnemyFromList;
           GameApplication.Instance.GetService<IStateMachineService>().OnStartReplay += StartReplay;
        }

        private void SpawnEnemyControllers()
        {
            if (listOfEnemies.isUnique)
            {
                if (listOfEnemies.enemiesToSpawn > listOfEnemies.enemyList.Count)
                {
                    Debug.Log("More scirptable objects needed");
                    return;
                }
            }
            for (int i = 0; i < listOfEnemies.enemiesToSpawn; i++)
            {
                EnemyData newData = new EnemyData();
                int index = UnityEngine.Random.Range(0, listOfEnemies.enemyList.Count);
                newData.indexOfScriptableObj = index;
                EnemyScriptableObject _newEnemyObj = listOfEnemies.enemyList.ElementAt(index);
                newData.spawnPosition = CreateEnemyController(_newEnemyObj);

                enemyDataList.Add(newData);
            }

        }

        public Vector3 CreateEnemyController(EnemyScriptableObject _enemyScriptableObject, Vector3? _spawnPos = null)
        {
            EnemyController enemy = objectPool.Get<EnemyController>(); 
            enemy.SetConstructorArguments( _enemyScriptableObject, _spawnPos = null);
           
            var view=enemy.GetView();       
            if(view==null)
            {
                Debug.Log("view null hai");
            }   
            var t=view.gameObject.transform;
            if(t==null)
            {
                Debug.Log("view null hai");
            }
            if(enemyHolder==null)
            {
                Debug.Log("holder null hai");
            }
            t.SetParent(enemyHolder.transform);
            var currentLocation = enemy.GetPosition();
            spawnedEnemies.Add(enemy);
            return currentLocation;
        }

        public void DestroyController(EnemyController _enemyController)
        {
        //    for(int i=0;i<spawnedEnemies.Count;i++)
        //    {
        //        if(spawnedEnemies[i]==_enemyController)
        //        {
        //            spawnedEnemies.RemoveAt(i);
        //            break;
        //        }
        //    }


            _enemyController.Reset();
            //_enemyController = null;
        }

        public List<EnemyController> GetEnemyList()
        {
            return spawnedEnemies;
        }

        public void RemoveEnemyFromList(int _id, EnemyType _type, int playerID)
        {
            foreach (EnemyController _enemy in spawnedEnemies)
            {
                if (_enemy.GetID() == _id)
                {
                    ReturnToPool(_enemy);
                    spawnedEnemies.Remove(_enemy);
                    return;
                }

            }
        }

        public void OnEnemyDeath(int _id, EnemyType _type, int _pid)
        {
            GameApplication.Instance.GetService<IPlayerService>().AddKillCount(_pid);
            EnemyDeath?.Invoke(_id, _type, _pid);
        }

        public void SetDamagingPlayerID(int _playerID)
        {
            currentDamagingID = _playerID;

        }
        public int GetDamagingPlayerID()
        {
            return currentDamagingID;
        }
        public void AlertAllEnemies(Vector3 _lastKnownPlayerLocation)
        {
            PlayerSpotted?.Invoke(_lastKnownPlayerLocation);
        }

        public void StartReplay()
        {
            // for (int i = 0; i < spawnedEnemies.Count; i++)
            // {
            //     EnemyController item = spawnedEnemies.ElementAt(i);
            //     DestroyController(item);
            // }
            // spawnedEnemies.Clear();
            // Debug.Log(enemyDataList.Count);
            foreach (EnemyData _data in enemyDataList)
            {
                Vector3 temp = CreateEnemyController(listOfEnemies.enemyList.ElementAt(_data.indexOfScriptableObj), _data.spawnPosition);
                Debug.Log("temp value" + temp);
            }
        }

        void ReturnToPool(EnemyController _enemyController)
        {
            objectPool.ReturnToPool(_enemyController);
        }
    }
}