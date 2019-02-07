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

        protected KeyCode pauseKey;

        private float verticalVal;
        private float horizontalVal;

        public bool isPaused = false;
        protected PlayerController currentPlayerController;

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
            if (Input.GetKey(GetPauseKey()))
            {
                PauseGame();
            }

            if (!isPaused)
            {
                if (Input.GetKey(GetFireInput()))
                {
                    currentPlayerController.Fire();
                    SetFireState(true);                    
                }
                else
                {
                    SetFireState(false);
                }
                
                if (Input.GetKey(GetMoveUpInput()))
                {
                    MoveUp();
                    return;
                }
                if (Input.GetKey(GetMoveDownInput()))
                {
                    MoveDown();
                    return;
                }
                if (Input.GetKey(GetMoveLeftInput()))
                {
                    MoveLeft();
                    return;
                }
                if (Input.GetKey(GetMoveRightInput()))
                {
                    MoveRight();
                    return;
                }                                
                
                SetPlayerIdle();
                
            }
        }

        private void PauseGame()
        {
            GetPlayerController().PauseGame();
            InputManagerBase.Instance.SetPauseGame();
        }
        private void SetFireState(bool _isFiring)
        {
            GetPlayerController().SetFireState(_isFiring);
        }
        private void SetPlayerIdle()
        {
            GetPlayerController().PlayerIdle();
        }
        private void MoveUp()
        {
            verticalVal = 1f;
            horizontalVal = 0;
            GetPlayerController().Move(horizontalVal, verticalVal);
        }
        private void MoveDown()
        {
            verticalVal = -1f;
            horizontalVal = 0;
            GetPlayerController().Move(horizontalVal, verticalVal);
        }
        private void MoveLeft()
        {
            verticalVal = 0;
            horizontalVal = -1;
            GetPlayerController().Move(horizontalVal, verticalVal);
        }
        private void MoveRight()
        {
            verticalVal = 0;
            horizontalVal = 1;
            GetPlayerController().Move(horizontalVal, verticalVal);

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
        public virtual KeyCode GetPauseKey()
        {
            return pauseKey;
        }
    }
}