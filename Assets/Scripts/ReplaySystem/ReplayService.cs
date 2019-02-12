using UnityEngine;
using Common;
using InputComponents;
using System;
using System.Collections.Generic;

namespace ReplaySystem
{
    public class ReplayService : SingletonBase<ReplayService>
    {
        private bool startReplay = false;
        Queue<QueueData> savedQueueData = new Queue<QueueData>();

        private void Start()
        {
            StateMachineImplementation.StateMachineService.Instance.OnStartReplay += StartReplay;
        }

        public bool GetReplayValue()
        {
            return startReplay;
        }

        private void StartReplay()
        {
            startReplay = true;
            Player.PlayerService.Instance.OnStart();
        }

        public void SaveQueue(QueueData _dataToSave)
        {
            savedQueueData.Enqueue(_dataToSave);
        }

        public Queue<QueueData> GetSavedQueue()
        {
            return savedQueueData;
        }

        public void SaveSpawnPointData(int _id, int _frameNo, InputActions _spawnAction)
        {
           QueueData newData= new QueueData();
           newData.actions.Add(_spawnAction);
           newData.controllerID=_id;
           newData.frameNo=_frameNo;

           savedQueueData.Enqueue(newData);
        }
    }
}