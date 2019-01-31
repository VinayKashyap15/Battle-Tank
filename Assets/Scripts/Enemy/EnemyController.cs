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


        private void SpawnEnemy(EnemyModel _enemyModel,Vector3 _position)
        {
           GameObject currentModel= GameObject.Instantiate(_enemyModel.GetEnemyModel());
            currentModel.transform.position = _position;
           
            currentModel.GetComponentInChildren<Renderer>().sharedMaterial = _enemyModel.GetEnemyMaterial();
            currentEnemyView = currentModel.GetComponent<EnemyView>();

            currentEnemyView.SetController(this);   
        }

        private void CreateModel(EnemyScriptableObject _enemyScriptableObject)
        {
            EnemyModel _enemyModel = new EnemyModel(_enemyScriptableObject);
            currentEnemyModel = _enemyModel;
            SpawnEnemy(_enemyModel,_enemyScriptableObject.pos);
        }

        public virtual void StartDestroy()
        {
            currentEnemyModel = null;
        }
    }
}