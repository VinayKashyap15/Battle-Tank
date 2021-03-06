﻿using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "NewPlayerPrefab", menuName = "Custom Objects/Player/Prefab", order = 0)]
   public class PlayerPrefabScriptableObject: ScriptableObject
    {
        public GameObject newPlayerPrefab; 
    }
}