using UnityEngine;
using ServiceLocator;
using GameplayInterfaces;
using Player;
using Bullet.Model;
using Bullet.View;
using Weapons.Bullet;
using ObjectPooling;
using System;

namespace Bullet.Controller
{
    public class BulletController:IPoolable
    {

        private GameObject bulletInstance;
        private GameObject _bulletPrefab;
        private BulletModel currentBulletModel;
        private BulletView currentBulletView;


        protected Player.PlayerController currentPlayerController;

        public event Action<ITakeDamage,int> HasCollided;

        public BulletController()
        {
            currentBulletModel = CreateModel();

            SpawnBullet();
        }

        private void SpawnBullet()
        {
            if (!_bulletPrefab)
            {
                _bulletPrefab = Resources.Load("Bullet") as GameObject;
            }

            bulletInstance = GameObject.Instantiate(_bulletPrefab);
            currentBulletView = bulletInstance.GetComponent<BulletView>();
            currentBulletView.SetController(this);
            SetPlayerControllerInstance();
            HasCollided+= currentPlayerController.CheckCollision;

        }

        public void SetViewActive()
        {
           currentBulletView.gameObject.SetActive(true);
           currentBulletView.SetOriginalVelocity();
        }

        protected virtual BulletModel CreateModel()
        {
            return new BulletModel();
        }
        public virtual BulletView GetBulletView()
        {
            return currentBulletView;
        }

        public GameObject GetBullet()
        {
            return bulletInstance;
        }

        public float GetBulletSpeed()
        {
            return currentBulletModel.GetBulletSpeed();
        }

        public float GetFireRate()
        {
            return currentBulletModel.GetFireRate();
        }

        public virtual void StartDestroy()
        {
            currentBulletModel = null;
            HasCollided -= currentPlayerController.CheckCollision;
        }

        public void FireBullet(Vector3 _firePosition, Quaternion _fireRotation, Vector3 _fireDirection)
        {            
           currentBulletView.FireBullet(bulletInstance, _firePosition, _fireRotation, _fireDirection, GetBulletSpeed());
        }

        public virtual void SetPlayerControllerInstance()
        {
            currentPlayerController = GameApplication.Instance.GetService<IBulletService>().GetPlayerControllerInstance();
        }

        public void InvokeAction(ITakeDamage _currentView)
        {
            HasCollided?.Invoke(_currentView,currentBulletModel.GetPointDamage());
        }

        public void Reset()
        {
            currentBulletView.Reset();
        }

    }
}