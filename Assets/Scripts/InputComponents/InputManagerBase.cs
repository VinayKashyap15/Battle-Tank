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
    public class InputManagerBase : IInputManagerService
    {

        private Queue<QueueData> saveQueue = new Queue<QueueData>();
        
        bool isReplayPaused = false;
        public InputManagerBase()
        {
            OnStart();
        }
        public void OnStart()
        {
           GameApplication.Instance.GetService<IStateMachineService>().OnPause+=ReplayPaused;
        }
        public void OnUpdate()
        {
            
                if (GameApplication.Instance.GetService<IReplayService>().GetReplayValue())
                {
                    ReplayUpdate(GameApplication.Instance.GetService<IReplayService>().GetSavedQueue());
                }
                else
                {
                    InputUpdate();

                }
            
        }

        private void InputUpdate()
        {
            int frameNo = GameApplication.Instance.GetService<ISceneLoader>().GetStartFrameTime();

            foreach (var _currentPlayerController in GameApplication.Instance.GetService<IPlayerService>().GetListOfPlayerControllers())
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
        private void ReplayUpdate(Queue<QueueData> _recievedQueue)
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
            foreach (var _currentPlayerController in GameApplication.Instance.GetService<IPlayerService>().GetListOfPlayerControllers())
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

        private void SaveInQueue(int _controllerID, int _frameNo, List<InputActions> _currentActionList)
        {
            QueueData newData = new QueueData();
            newData.actions = _currentActionList;
            newData.controllerID = _controllerID;
            newData.frameNo = _frameNo;

            saveQueue.Enqueue(newData);
            GameApplication.Instance.GetService<IReplayService>().SaveQueue(newData);
        }
        private void ReplayPaused()
        {
            isReplayPaused=!isReplayPaused;            
        }

       
    }
}
