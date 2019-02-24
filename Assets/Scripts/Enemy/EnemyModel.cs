using UnityEngine;

namespace Enemy
{
   public  class EnemyModel
    {

        private EnemyType enemyType;
        private float enemySpeed;
        private static int enemyID=0;
        
        private Material enemyMaterial;
        private GameObject enemyModel;
        private int health;  

        public EnemyModel(EnemyScriptableObject _enemyScriptableObject)
        {
            enemyMaterial = _enemyScriptableObject.enemyMaterial;
            enemySpeed = _enemyScriptableObject.enemySpeed;
            enemyModel = _enemyScriptableObject.enemyPrefab;
            health = _enemyScriptableObject.enemyHealth;
            enemyType = _enemyScriptableObject.type;
            enemyID += 1;
        }

        public int GetID()
        {
            return enemyID;
        }
        public EnemyType GetEnemyType()
        {
            return enemyType;
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
