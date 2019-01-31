using Common;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    public class EnemyService : SingletonBase<EnemyService>
    {
        public EnemyScriptableObjectList listOfEnemies;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            SpawnEnemyControllers();
        }

        private void SpawnEnemyControllers()
        {
            //Check if enemies to spawn is greater than scripatble objects provided
            if(listOfEnemies.enemiesToSpawn>listOfEnemies.enemyList.Count)
            {
                Debug.Log("More scirptable objects needed");
                return;
            }

            //for loop to spawn enemies
            for(int i=0;i<listOfEnemies.enemiesToSpawn;i++)
            {
                //Random object from the list
                EnemyScriptableObject _newEnemyObj = listOfEnemies.enemyList.ElementAt(UnityEngine.Random.Range(0, listOfEnemies.enemyList.Count));
                CreateEnemyController(_newEnemyObj);
            }
        }

        public void CreateEnemyController(EnemyScriptableObject _enemyScriptableObject)
        {
            new EnemyController(_enemyScriptableObject);
        }

        public void DestroyController(EnemyController _enemyController)
        {
            _enemyController.StartDestroy();
            _enemyController = null;
        }
    }
}