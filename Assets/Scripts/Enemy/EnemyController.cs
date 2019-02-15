using System;
using GameplayInterfaces;
using EnemyStates;
using UnityEngine;

namespace Enemy
{
    public class EnemyController:ICharacterController
    {
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyModel currentEnemyModel;
        private EnemyView currentEnemyView;
        int enemyID;
        public IEnemyState currentState;
        private EnemyStateMachine currentStateMachine;
        public  IEnemyState previousState;

        public EnemyController(EnemyScriptableObject _enemyScriptableObject)
        {
            enemyScriptableObject = _enemyScriptableObject;
            CreateModel(_enemyScriptableObject);
            currentStateMachine= new EnemyStateMachine(this);
            currentStateMachine.ChangeCurrentState(currentEnemyView.gameObject.GetComponent<PatrollingState>());        
            enemyID=currentEnemyModel.GetID();
            EnemyService.Instance.PlayerSpotted+=StartChasing;
        }

        private void StartChasing(Vector3 _position)
        {          
            currentEnemyView.gameObject.GetComponent<ChaseState>().lastSeenPosition=_position;
           currentStateMachine.ChangeCurrentState(currentEnemyView.gameObject.GetComponent<ChaseState>());
            
        }

        public void BackToPatrolling()
        {
            Debug.Log("back to patrol");
            currentStateMachine.ChangeCurrentState(currentEnemyView.gameObject.GetComponent<PatrollingState>());
            
        }

        private void SpawnEnemy(EnemyModel _enemyInstance,Vector3 _position)
        {
           GameObject currentEnemyInstance= GameObject.Instantiate(_enemyInstance.GetEnemyModel());
            currentEnemyInstance.transform.position = new Vector3(UnityEngine.Random.Range(-20,40),0,UnityEngine.Random.Range(-20,40)); 
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
            EnemyService.Instance.PlayerSpotted-=StartChasing;
            currentEnemyModel = null;
            currentState=null;
            currentEnemyView.DestroySelf();
        }

        public Vector3 GetPosition()
        {
            return currentEnemyView.GetPosition();
        }

        public void DamageEnemy(int _damage)
        {
            currentEnemyModel.SetEnemyHealth(currentEnemyModel.GetEnemyHealth() - _damage);
            if(currentEnemyModel.GetEnemyHealth()<=0)
            {
                EnemyService.Instance.OnEnemyDeath(GetID(),currentEnemyModel.GetEnemyType(),EnemyService.Instance.GetDamagingPlayerID());
                EnemyService.Instance.DestroyController(this);
                
            }
        }

        public int GetID()
        {
            return enemyID;
        }

        public void Fire()
        {
            //fire;
        }

        public void Move(float h, float v)
        {
            //move enemy;
        }

        public void PauseGame()
        {
            //throw new NotImplementedException();
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