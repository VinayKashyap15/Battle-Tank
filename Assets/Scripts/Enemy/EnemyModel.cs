using UnityEngine;

namespace Enemy
{
    class EnemyModel
    {
        private float enemySpeed;
        private Material enemyMaterial;
        private GameObject enemyModel;       

        public EnemyModel(EnemyScriptableObject _enemyScriptableObject)
        {          
            this.enemyMaterial = _enemyScriptableObject.enemyMaterial;
            this.enemySpeed = _enemyScriptableObject.enemySpeed;
            this.enemyModel = _enemyScriptableObject.enemyPrefab;

        }

        //speed for enemy movement to be written
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

    }
}
