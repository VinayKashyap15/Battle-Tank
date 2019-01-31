using UnityEngine;
using Common;
using Player;
using System;

namespace InputComponents
{
    public class InputComponent
    {
        protected KeyCode fireKey;
        protected KeyCode moveForwardKey;
        protected KeyCode moveBackwardKey;
        protected KeyCode moveLeftKey;
        protected KeyCode moveRightKey;

        private float verticalVal;
        private float horizontalVal;
        protected  PlayerController currentPlayerController;
         
        public InputComponent()
        {
            fireKey = KeyCode.Space;         

        }

        protected virtual PlayerController GetPlayerController()
        {
            return currentPlayerController;
        }
        public void OnUpdate()
        {
            if (Input.GetKey(GetFireInput()))
            {
                InputManagerBase.Instance.FireAction(currentPlayerController);
            }
            if (Input.GetKey(GetMoveUpInput()))
            {
                MoveUp();
            }
            if (Input.GetKey(GetMoveDownInput()))
            {
                MoveDown();
            }
            if (Input.GetKey(GetMoveLeftInput()))
            {
                MoveLeft();
            }
            if (Input.GetKey(GetMoveRightInput()))
            {
                MoveRight();
            }
        }

        private void MoveUp()
        {
            verticalVal = 1f;
            horizontalVal = 0;
            InputManagerBase.Instance.MoveAction(GetPlayerController(),horizontalVal,verticalVal);
        }
        private void MoveDown()
        {
            verticalVal = -1f;
            horizontalVal = 0;
            InputManagerBase.Instance.MoveAction(GetPlayerController(), horizontalVal, verticalVal);
        }
        private void MoveLeft()
        {
            verticalVal = 0;
            horizontalVal = -1;
            InputManagerBase.Instance.MoveAction(GetPlayerController(), horizontalVal, verticalVal);
        }
        private void MoveRight()
        {
            verticalVal = 0;
            horizontalVal = 1;
            InputManagerBase.Instance.MoveAction(GetPlayerController(), horizontalVal, verticalVal);

        }

        public virtual KeyCode GetFireInput()
        {
            return fireKey;
        }

        public virtual KeyCode GetMoveUpInput()
        {
            return moveForwardKey;
        }

        public virtual KeyCode GetMoveDownInput()
        {
            return moveBackwardKey;
        }

        public virtual KeyCode GetMoveLeftInput()
        {
            return moveLeftKey;
        }

        public virtual KeyCode GetMoveRightInput()
        {
            return moveRightKey;
        }
        
    }
}