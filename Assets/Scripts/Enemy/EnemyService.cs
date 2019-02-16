using Common;
using AchievementSystem;
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
    public class EnemyService : SingletonBase<EnemyService>
    {
        [SerializeField] private EnemyScriptableObjectList listOfEnemies;

        public List<EnemyData> enemyDataList = new List<EnemyData>();
        private List<EnemyController> spawnedEnemies = new List<EnemyController>();
        public event Action<int, EnemyType, int> EnemyDeath;
        public event Action<Vector3> PlayerSpotted;
        int currentDamagingID;
        public void OnStart()
        {
            SpawnEnemyControllers();
            RegisterEvent();
        }
        public void OnUpdate()
        {
            // foreach (EnemyController item in spawnedEnemies)
            // {
            //     if (item.currentState != null)
            //     {
            //         item.currentState.OnStateUpdate();
            //     }
            // }
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
            StateMachineImplementation.StateMachineService.Instance.OnStartReplay += StartReplay;
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
            var enemy = new EnemyController(_enemyScriptableObject, _spawnPos);
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


            _enemyController.StartDestroy();
            _enemyController = null;
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
                    spawnedEnemies.Remove(_enemy);
                    return;
                }

            }
        }

        public void OnEnemyDeath(int _id, EnemyType _type, int _pid)
        {
            Player.PlayerService.Instance.AddKillCount(_pid);
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
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                EnemyController item = spawnedEnemies.ElementAt(i);
                DestroyController(item);
            }
            spawnedEnemies.Clear();
            Debug.Log(enemyDataList.Count);
            foreach (EnemyData _data in enemyDataList)
            {
                Vector3 temp = CreateEnemyController(listOfEnemies.enemyList.ElementAt(_data.indexOfScriptableObj), _data.spawnPosition);
            }
        }

    }
}