using UnityEngine;
using Common;
using Player;
using System;

namespace InputComponents
{
    public class InputComponent 
    {
        private KeyCode fireKey;
        private InputComponent currentInputComponent;
        private PlayerController currentPlayerController;

        public InputComponent()
        {
            fireKey = KeyCode.Space;  
           
        }

        public void OnUpdate()
        {
            if(Input.GetKey(GetFireInput()))
            {
                InputManagerBase.Instance.FireAction(PlayerService.Instance.GetCurrentPlayerController());
            }
        }

        public virtual KeyCode GetFireInput()
        {
            return fireKey;
        }
       
    }
}