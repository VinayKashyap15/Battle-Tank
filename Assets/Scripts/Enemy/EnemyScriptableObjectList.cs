using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Enemy
{
    [RequireComponent(typeof(EnemyScriptableObject))]
    [CreateAssetMenu(fileName = "NewEnemyObjectList", menuName = "Custom Objects/Enemy/Enemy Object List", order = 1)]
    public class EnemyScriptableObjectList :ScriptableObject
    {
        public List<EnemyScriptableObject> enemyList= new List<EnemyScriptableObject>();
        public int enemiesToSpawn;
        public bool isUnique;

    }
}
