using UnityEngine;
using Common;
using System.Collections.Generic;
using GameplayInterfaces;
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
        protected ICharacterController currentCharacterController;

        public InputComponent()
        {
            fireKey = KeyCode.Space;
        }
        protected virtual ICharacterController GetCharacterCoontroller()
        {
            return currentCharacterController;
        }

        public List<InputActions> OnUpdate()
        {
            //_actions.Clear();
            List<InputActions> actions=new List<InputActions>();
            if (Input.GetKey(GetPauseKey()))
            {
                PauseGame();
            }

            if (!isPaused)
            {
                if (Input.GetKey(GetFireInput()))
                {
                    actions.Add(Fire());
                    SetFireState(true);                    
                }
                else
                {
                    SetFireState(false);
                }
                
                if (Input.GetKey(GetMoveUpInput()))
                {
                    actions.Add(MoveUp());
                    
                }
                if (Input.GetKey(GetMoveDownInput()))
                {
                   actions.Add( MoveDown());
                    
                }
                if (Input.GetKey(GetMoveLeftInput()))
                {
                   actions.Add( MoveLeft());
                   
                }
                if (Input.GetKey(GetMoveRightInput()))
                {
                   actions.Add( MoveRight());
                    
                }                                                      
                
            }
            return actions;
        }

        private InputActions Fire()
        {            
            return new FireAction();           
            
        }

        private void PauseGame()
        {
            GetCharacterCoontroller().PauseGame();
            InputManagerBase.Instance.SetPauseGame();
        }
        private void SetFireState(bool _isFiring)
        {
            GetCharacterCoontroller().SetFireState(_isFiring);
        }
    
        private InputActions MoveUp()
        {
            verticalVal = 1f;
            horizontalVal = 0;           
            return new MoveAction(horizontalVal,verticalVal);
        }
        private InputActions MoveDown()
        {
            verticalVal = -1f;
            horizontalVal = 0;
          
            return new MoveAction(horizontalVal,verticalVal);
        }
        private InputActions MoveLeft()
        {
            verticalVal = 0;
            horizontalVal = -1;
           
            return new MoveAction(horizontalVal,verticalVal);
        }
        private InputActions MoveRight()
        {
            verticalVal = 0;
            horizontalVal = 1;
            return new MoveAction(horizontalVal,verticalVal);

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