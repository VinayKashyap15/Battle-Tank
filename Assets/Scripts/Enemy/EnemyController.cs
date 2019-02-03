using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyModel currentEnemyModel;
        private EnemyView currentEnemyView;

        public EnemyController(EnemyScriptableObject _enemyScriptableObject)
        {
            enemyScriptableObject = _enemyScriptableObject;
            CreateModel(_enemyScriptableObject);           
        }


        private void SpawnEnemy(EnemyModel _enemyInstance,Vector3 _position)
        {
           GameObject currentEnemyInstance= GameObject.Instantiate(_enemyInstance.GetEnemyModel());
            currentEnemyInstance.transform.position = _position;           
            currentEnemyView = currentEnemyInstance.GetComponent<EnemyView>();
            currentEnemyView.SetMaterial(_enemyInstance.GetEnemyMaterial());
            currentEnemyView.SetController(this);   
        }

        private void CreateModel(EnemyScriptableObject _enemyScriptableObject)
        {
            EnemyModel _enemyModel = new EnemyModel(_enemyScriptableObject);
            currentEnemyModel = _enemyModel;
            SpawnEnemy(_enemyModel,_enemyScriptableObject.pos);
        }

        public  void StartDestroy()
        {
            currentEnemyModel = null;
        }

        public Vector3 GetPosition()
        {
            return currentEnemyView.GetPosition();
        }
    }
}