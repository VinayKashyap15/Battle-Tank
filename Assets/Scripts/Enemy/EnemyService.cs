using Common;
using AchievementSystem;
using System;
using UnityEngine;
using System.Collections.Generic;
using GameplayInterfaces;
using System.Linq;

namespace Enemy
{
    public class EnemyService : SingletonBase<EnemyService>
    {
        [SerializeField] private EnemyScriptableObjectList listOfEnemies;
        private List<EnemyController> spawnedEnemies = new List<EnemyController>();
        public event Action<int, EnemyType, int> EnemyDeath;
        public event Action<ICharacterController> PlayerSpotted;
        int currentDamagingID;
        public void OnStart()
        {

            SpawnEnemyControllers();
            RegisterEvent();
        }
        public void OnUpdate()
        {
            foreach (EnemyController item in spawnedEnemies)
            {
                if (item.currentState != null)
                {
                    item.currentState.OnStateUpdate();
                }
            }
        }
        private void RegisterEvent()
        {
            EnemyDeath += RemoveEnemyFromList;

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
                EnemyScriptableObject _newEnemyObj = listOfEnemies.enemyList.ElementAt(UnityEngine.Random.Range(0, listOfEnemies.enemyList.Count));
                CreateEnemyController(_newEnemyObj);
            }

        }

        public void CreateEnemyController(EnemyScriptableObject _enemyScriptableObject)
        {
            var enemy = new EnemyController(_enemyScriptableObject);
            spawnedEnemies.Add(enemy);
        }

        public void DestroyController(EnemyController _enemyController)
        {
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
            EnemyDeath.Invoke(_id, _type, _pid);
        }

        public void SetDamagingPlayerID(int _playerID)
        {
            currentDamagingID = _playerID;

        }
        public int GetDamagingPlayerID()
        {
            return currentDamagingID;
        }
        public void AlertAllEnemies(ICharacterController _spottedPlayer)
        {
            PlayerSpotted.Invoke(_spottedPlayer);
        }
    }
}