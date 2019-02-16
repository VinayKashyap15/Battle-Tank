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
        protected KeyCode rotateLeftKey;
        protected KeyCode rotateRightKey;
        
        
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
           
            List<InputActions> actions=new List<InputActions>();
            if (Input.GetKeyDown(GetPauseKey()))
            {
                PauseGame();
            }

            if (!isPaused)
            {
                if (Input.GetKeyDown(GetFireInput()))
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
                if (Input.GetKey(GetRotateLeftInput()))
                {
                   actions.Add( RotateLeft());
                   
                }
                if (Input.GetKey(GetRotateRightInput()))
                {
                   actions.Add( RotateRight());
                    
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
            StateMachineImplementation.StateMachineService.Instance.SetGamePause();
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
        private InputActions RotateLeft()
        {
            int pitch=-1;                       
            return new RotateAction(pitch);
        }
       private InputActions RotateRight()
        {
            int pitch=1;                       
            return new RotateAction(pitch);
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
        public virtual KeyCode GetRotateLeftInput()
        {
            return rotateLeftKey;
        }
        public virtual KeyCode GetRotateRightInput()
        {
            return rotateRightKey;
        }
        public virtual KeyCode GetPauseKey()
        {
            return pauseKey;
        }
    }
}