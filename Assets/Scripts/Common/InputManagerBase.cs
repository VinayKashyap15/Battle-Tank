using InputComponents;
using Player;
using Enemy;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Common
{
    public class InputManagerBase : SingletonBase<InputManagerBase>
    {
       
        [SerializeField]
        private List<EnemyController> listOfEnemyControllers = new List<EnemyController>();
       
        
        private void Update()
        {
            foreach (PlayerController _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                _currentPlayerController.GetInputComponent().OnUpdate();
            }
        }

       
    }
}
