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

        public EnemyState currentState;

        public EnemyController(EnemyScriptableObject _enemyScriptableObject)
        {
            enemyScriptableObject = _enemyScriptableObject;
            CreateModel(_enemyScriptableObject);           
            EnemyService.Instance.PlayerSpotted+=StartChasing;
        }

        private void StartChasing(ICharacterController _spottedPlayer)
        {
           currentState= new ChaseState(this,_spottedPlayer);
        }

        private void SpawnEnemy(EnemyModel _enemyInstance,Vector3 _position)
        {
           GameObject currentEnemyInstance= GameObject.Instantiate(_enemyInstance.GetEnemyModel());
            currentEnemyInstance.transform.position = new Vector3(UnityEngine.Random.Range(5,40),0,UnityEngine.Random.Range(5,40)); 
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
                currentEnemyView.DestroySelf();
                EnemyService.Instance.DestroyController(this);
            }
        }

        public int GetID()
        {
            return currentEnemyModel.GetID();
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

        public Vector3 GetCurrentLocation()
        {
            return currentEnemyView.gameObject.transform.position;
        }

        public void SetNewLocation(Vector3 _pos)
        {
           currentEnemyView.gameObject.transform.position= Vector3.Lerp(currentEnemyView.gameObject.transform.position,_pos,0.1f*Time.deltaTime);
        }
    }
}