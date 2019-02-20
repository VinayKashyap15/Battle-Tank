using SceneSpecific;
using UnityEngine;
using System.Collections.Generic;
using System;
using InputComponents;
using Player;

namespace GameplayInterfaces
{
    public interface IPlayerService : IService
    {
        event Action RegenerateHealth;
        event Action<int, int> PlayerDeath;
        event Action<int, int> HighScoreUpdate;
        event Action<int, int> EnemyKill;
        event Action UpdatePlayer;

        void OnStart(SceneController _currentSceneController);
        void SetSpawnPos(Vector3 position);
        void SaveMaterialFromReward(Material materialToSave);
        void OnUpdate();
        void SpawnPlayers();
        void DestroyPlayer(PlayerController _playerController);
        void SetCurrentInstance(PlayerController _playerControllerInstance);
        void UpdateScoreView(PlayerController _p, int _score, int _playerID);
        Vector3 GetRespawnSafePosition();
        void InvokePlayerDeath(int _id, int _dieActionCalled);
        void InvokePlayerScore(int _enemyID, Enemy.EnemyType _type, int playerID);
        void InvokeHighScoreAchievement(int _id, int _highScore);
        void AddKillCount(int _playerID);
        int GetNoOfPlayers();
        List<PlayerController> GetListOfPlayerControllers();
    }
}