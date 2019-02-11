using Common;
using GameplayInterfaces;
using System.Collections.Generic;
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
        private Queue<QueueData> saveQueue= new Queue<QueueData>();

        [SerializeField]
        private List<InputActions> actionsToPerform=new List<InputActions>();
        private void Update()
        {
            int frameNo = Time.frameCount;
            //actionsToPerform.Clear();
            foreach (var _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                actionsToPerform = _currentPlayerController.GetInputComponent().OnUpdate();

                if (actionsToPerform.Count != 0)
                {
                    PerformAction(_currentPlayerController);
                    SaveInQueue(_currentPlayerController.GetID(), frameNo, actionsToPerform);
                }
                else
                {
                    _currentPlayerController.PlayerIdle();
                }
            }
        }

        private void PerformAction(ICharacterController _controller)
        {
            foreach(InputActions item in actionsToPerform)
            {
                item.Execute(_controller);
            }
        }

        public void SaveInQueue(int _controllerID, int _frameNo, List<InputActions> _currentActionList)
        {
            QueueData newData = new QueueData();
            newData.actions = _currentActionList;
            newData.controllerID = _controllerID;
            newData.frameNo = _frameNo;

            saveQueue.Enqueue(newData);
            Debug.Log(saveQueue.Peek());

        }

        public void ReadFromQueue()
        {
            QueueData qData = saveQueue.Peek();           
            saveQueue.Dequeue();

        }
        public void SetPauseGame()
        {
            StateMachineImplementation.StateMachineService.Instance.SetGamePause();
        }

    }
}
