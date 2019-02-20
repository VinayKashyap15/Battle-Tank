using System;
using GameplayInterfaces;
using ServiceLocator;
using EnemyStates;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : ICharacterController
    {
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyModel currentEnemyModel;
        private EnemyView currentEnemyView;
        int enemyID;
        public IEnemyState currentState;
        private EnemyStateMachine currentStateMachine;
        public IEnemyState previousState;

        public EnemyController(EnemyScriptableObject _enemyScriptableObject, Vector3? _spawnPos = null)
        {
            enemyScriptableObject = _enemyScriptableObject;
            if (_spawnPos != null)
            {
                CreateModel(_enemyScriptableObject, _spawnPos);
            }
            else { CreateModel(_enemyScriptableObject); }
            currentStateMachine = new EnemyStateMachine(this);
            currentState = currentEnemyView.gameObject.GetComponent<PatrollingState>();
            currentStateMachine.ChangeCurrentState(currentEnemyView.gameObject.GetComponent<PatrollingState>());
            enemyID = currentEnemyModel.GetID();
            GameApplication.Instance.GetService<IEnemyService>().PlayerSpotted += StartChasing;
        }

        public float GetEnemySpeed()
        {
            return currentEnemyModel.GetEnemySpeed();
        }

        private void StartChasing(Vector3 _position)
        {
            
            previousState=currentState;

            if (currentEnemyView == null)
            {
                return;
            }
            currentEnemyView.gameObject.GetComponent<ChaseState>().lastSeenPosition = _position;
            currentStateMachine.ChangeCurrentState(currentEnemyView.gameObject.GetComponent<ChaseState>());

        }

        public void BackToPatrolling()
        {
            
            previousState=currentState;
            
            currentStateMachine.ChangeCurrentState(currentEnemyView.gameObject.GetComponent<PatrollingState>());

        }
        private void CreateModel(EnemyScriptableObject _enemyScriptableObject, Vector3? _spawnPos = null)
        {
            EnemyModel _enemyModel = new EnemyModel(_enemyScriptableObject);
            currentEnemyModel = _enemyModel;
            if (_spawnPos != null)
            {
                SpawnEnemy(_enemyModel, _spawnPos);
            }
            else
            {
                SpawnEnemy(_enemyModel);
            }
        }

        private void SpawnEnemy(EnemyModel _enemyInstance, Vector3? _position = null)
        {
            GameObject currentEnemyInstance = GameObject.Instantiate(_enemyInstance.GetEnemyModel());
            if (_position != null)
            {
                currentEnemyInstance.transform.position = (Vector3)_position;

            }
            else { currentEnemyInstance.transform.position = new Vector3(UnityEngine.Random.Range(-20, 40), 0, UnityEngine.Random.Range(-20, 40)); }
            currentEnemyView = currentEnemyInstance.GetComponent<EnemyView>();
            currentEnemyView.SetMaterial(_enemyInstance.GetEnemyMaterial());
            currentEnemyView.SetController(this);
        }


        public void StartDestroy()
        {
            GameApplication.Instance.GetService<IEnemyService>().PlayerSpotted -= StartChasing;
            currentEnemyModel = null;
            currentState = null;
            currentEnemyView.DestroySelf();
            currentEnemyView = null;
        }

        public Vector3 GetPosition()
        {
            return currentEnemyView.GetPosition();
        }

        public void DamageEnemy(int _damage)
        {
            currentEnemyModel.SetEnemyHealth(currentEnemyModel.GetEnemyHealth() - _damage);
            if (currentEnemyModel.GetEnemyHealth() <= 0)
            {
                GameApplication.Instance.GetService<IEnemyService>().OnEnemyDeath(GetID(), currentEnemyModel.GetEnemyType(), GameApplication.Instance.GetService<IEnemyService>().GetDamagingPlayerID());
                GameApplication.Instance.GetService<IEnemyService>().DestroyController(this);

            }
        }

        public int GetID()
        {
            return enemyID;
        }

        public void Rotate(float _p)
        {

        }
        public void Fire()
        {
            //fire;
        }

        public void Move(float h, float v)
        {
            //move enemy;
        }

      
        public void SetFireState(bool isFiring)
        {
            //throw new NotImplementedException();
        }

        public void PlayerIdle()
        {
            //throw new NotImplementedException();
        }

    }
}