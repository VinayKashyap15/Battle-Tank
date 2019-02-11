using Common;
using GameplayInterfaces;
using System.Collections.Generic;
using ReplaySystem;
using Player;
using UnityEngine;
using System;

namespace InputComponents
{
    [System.Serializable]
    public struct QueueData
    {
        public List<InputActions> actions;
        public int controllerID;
        public int frameNo;
    }
    public class InputManagerBase : SingletonBase<InputManagerBase>
    {
        //private QueueData queueData;
        [SerializeField]
        private Queue<QueueData> saveQueue = new Queue<QueueData>();



        int startTime;
        private void Start()
        {
            startTime = Time.frameCount;
        }
        private void Update()
        {
            if (!ReplayService.Instance.GetReplayValue())
            {
                InputUpdate();
            }
            ReplayUpdate();

        }

        public void InputUpdate()
        {
            int frameNo = Math.Abs(startTime - Time.frameCount);
           
            foreach (var _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                List<InputActions> actionsToPerform = _currentPlayerController.GetInputComponent().OnUpdate();

                if (actionsToPerform.Count != 0)
                {
                    SaveInQueue(_currentPlayerController.GetID(), frameNo, actionsToPerform);
                }
                else
                {
                    _currentPlayerController.PlayerIdle();
                }
            }
        }
        public void ReplayUpdate()
        {
            foreach (var _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                PerformAction(_currentPlayerController, saveQueue);
            }
        }
        private void PerformAction(ICharacterController _controller, Queue<QueueData> _queueToRead)
        {
            while (_queueToRead.Count != 0)
            {
                QueueData queueData = _queueToRead.Peek();
                foreach (InputActions _action in queueData.actions)
                {
                    _action.Execute(_controller);
                    _queueToRead.Dequeue();
                }
            }
        }

        public void SaveInQueue(int _controllerID, int _frameNo, List<InputActions> _currentActionList)
        {
            QueueData newData = new QueueData();
            newData.actions = _currentActionList;
            newData.controllerID = _controllerID;
            newData.frameNo = _frameNo;

            saveQueue.Enqueue(newData);

        }

        public void SetPauseGame()
        {
            StateMachineImplementation.StateMachineService.Instance.SetGamePause();
        }

    }
}
