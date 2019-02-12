using UnityEngine;
using Common;
using InputComponents;
using System;
using System.Collections.Generic;

namespace ReplaySystem
{
    public class ReplayService : SingletonBase<ReplayService>
    {
        public bool startReplay = false;
        Queue<QueueData> savedQueueData = new Queue<QueueData>();

        private void Start()
        {
            savedQueueData.Clear();
            StateMachineImplementation.StateMachineService.Instance.OnStartReplay += StartReplay;
        }

        public bool GetReplayValue()
        {
            return startReplay;
        }

        private void StartReplay()
        {
            startReplay = true;
            Player.PlayerService.Instance.SpawnPlayers();
        }

        public void SaveQueue(QueueData _dataToSave)
        {
            savedQueueData.Enqueue(_dataToSave);
        }

        public Queue<QueueData> GetSavedQueue()
        {
            if (savedQueueData.Count == 0)
            {
                SceneLoader.Instance.OnGameOver();
                startReplay = false;
            }
            return savedQueueData;
        }

        public void SaveSpawnPointData(int _id, int _frameNo, InputActions _spawnAction)
        {
            QueueData newData = new QueueData();
            newData.actions=new List<InputActions>();
            newData.actions.Add(_spawnAction);
            newData.controllerID = _id;
            newData.frameNo = _frameNo;

            savedQueueData.Enqueue(newData);
        }
    }
}