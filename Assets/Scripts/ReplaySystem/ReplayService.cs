using UnityEngine;
using ServiceLocator;
using GameplayInterfaces;
using Common;
using InputComponents;
using System;
using System.Collections.Generic;

namespace ReplaySystem
{
    public class ReplayService : IReplayService
    {
        public bool startReplay = false;
        Queue<QueueData> savedQueueData = new Queue<QueueData>();
        SceneSpecific.SceneController sceneController;

        public ReplayService()
        {
            savedQueueData.Clear();
            GameApplication.Instance.GetService<IStateMachineService>().OnStartReplay += StartReplay;
            
        }

        public void SetSceneController(SceneSpecific.SceneController _controller)
        {
            sceneController=_controller;
        }
        public bool GetReplayValue()
        {
            return startReplay;
        }

        private void StartReplay()
        {
            startReplay = true;
            GameApplication.Instance.GetService<IPlayerService>().OnStart(sceneController);
            GameApplication.Instance.GetService<IStateMachineService>().OnEnterGameOverScene+=ClearQueue;
        }

        public void ClearQueue()
        {
            savedQueueData.Clear();
        }
        public void SaveQueue(QueueData _dataToSave)
        {
            savedQueueData.Enqueue(_dataToSave);
        }

        public Queue<QueueData> GetSavedQueue()
        {
            if (savedQueueData.Count == 0)
            {
               GameApplication.Instance.GetService<ISceneLoader>().OnGameOver();
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