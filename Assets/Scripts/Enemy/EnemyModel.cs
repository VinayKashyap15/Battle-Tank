using UnityEngine;

namespace Enemy
{
    class EnemyModel
    {
        private float enemySpeed;
        private Material enemyMaterial;
        private GameObject enemyModel;
        private int health;  

        public EnemyModel(EnemyScriptableObject _enemyScriptableObject)
        {          
            this.enemyMaterial = _enemyScriptableObject.enemyMaterial;
            this.enemySpeed = _enemyScriptableObject.enemySpeed;
            this.enemyModel = _enemyScriptableObject.enemyPrefab;
            health = _enemyScriptableObject.enemyHealth;

        }

      
        public float GetEnemySpeed()
        {
            return enemySpeed;
        }
        public Material GetEnemyMaterial()
        {
            return enemyMaterial;
        }
        public GameObject GetEnemyModel()
        {            
            return enemyModel;
        }
        public int GetEnemyHealth()
        {
            return health;
        }
        public void SetEnemyHealth(int _newHealth)
        {
             health=_newHealth;
        }
    }
}
