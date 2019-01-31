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
        private List<PlayerController> listOfPlayerControllers = new List<PlayerController>();
        [SerializeField]
        private List<EnemyController> listOfEnemyControllers = new List<EnemyController>();

        protected override void OnInitialize()
        {
            base.OnInitialize();
           
        }

        public void PopulatePlayerList(PlayerController _playerController)
        {
           listOfPlayerControllers.Add(_playerController);
        }
        
        private void Update()
        {          
            
        }
    }
}
