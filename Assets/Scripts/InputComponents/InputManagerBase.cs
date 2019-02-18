using Common;
using ServiceLocator;
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

        private Queue<QueueData> saveQueue = new Queue<QueueData>();
        public int startTime;
        bool isReplayPaused = false;
        private void Start()
        {
            startTime = 0;
           GameApplication.Instance.GetService<IStateMachineService>().OnPause+=ReplayPaused;
        }
        private void Update()
        {
            if(!isReplayPaused)
            {
                startTime++;
            }
                if (GameApplication.Instance.GetService<IReplayService>().GetReplayValue())
                {
                    ReplayUpdate(GameApplication.Instance.GetService<IReplayService>().GetSavedQueue());
                }
                else
                {
                    InputUpdate();

                }
            
        }

        public void InputUpdate()
        {
            int frameNo = startTime;

            foreach (var _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                List<InputActions> actionsToPerform = _currentPlayerController.GetInputComponent().OnUpdate();

                if (actionsToPerform.Count != 0)
                {
                    SaveInQueue(_currentPlayerController.GetID(), frameNo, actionsToPerform);
                    if (saveQueue.Count != 0)
                    { PerformAction(_currentPlayerController, actionsToPerform); }
                }
                else
                {
                    _currentPlayerController.PlayerIdle();
                }
            }
        }
        public void ReplayUpdate(Queue<QueueData> _recievedQueue)
        {
            if(isReplayPaused)
            {
                return;
            }
            if (_recievedQueue == null)
            {
                GameApplication.Instance.GetService<ISceneLoader>().OnGameOver();
                return;
            }
            foreach (var _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                if (_recievedQueue == null)
                {
                    GameApplication.Instance.GetService<ISceneLoader>().OnGameOver();
                    return;
                }
                else
                {
                    QueueData data = new QueueData();
                    if (_recievedQueue.Count == 0)
                    {
                        GameApplication.Instance.GetService<ISceneLoader>().OnGameOver();
                        return;
                    }
                    data = _recievedQueue.Peek();
                    if (_currentPlayerController.GetID() == data.controllerID)
                    {
                        PerformAction(_currentPlayerController, data.actions);
                        _recievedQueue.Dequeue();

                    }
                }
            }
        }
        private void PerformAction(ICharacterController _controller, List<InputActions> _actionsToPerform)
        {
            foreach (InputActions _action in _actionsToPerform)
            {
                _action.Execute(_controller);
            }
        }

        public void SaveInQueue(int _controllerID, int _frameNo, List<InputActions> _currentActionList)
        {
            QueueData newData = new QueueData();
            newData.actions = _currentActionList;
            newData.controllerID = _controllerID;
            newData.frameNo = _frameNo;

            saveQueue.Enqueue(newData);
            GameApplication.Instance.GetService<IReplayService>().SaveQueue(newData);
        }

        public void ReplayPaused()
        {
            isReplayPaused=!isReplayPaused;            
        }

    }
}
