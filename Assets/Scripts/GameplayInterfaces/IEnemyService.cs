using System;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace GameplayInterfaces
{
    public interface IEnemyService : IService
    {
        event Action<int, EnemyType, int> EnemyDeath;
        event Action<Vector3> PlayerSpotted;
        void OnStart();
        void OnUpdate();
        Vector3 CreateEnemyController(EnemyScriptableObject _enemyScriptableObject, Vector3? _spawnPos = null);
        void DestroyController(EnemyController _enemyController);
        List<EnemyController> GetEnemyList();
        int GetDamagingPlayerID();
        
        void SetDamagingPlayerID(int _playerID);
        void OnEnemyDeath(int _id, EnemyType _type, int _pid);
        void RemoveEnemyFromList(int _id, EnemyType _type, int playerID);
        void StartReplay();
        void AlertAllEnemies(Vector3 _position);
    }
}