using UnityEngine;
using Interfaces;
using Player;
using Bullet.Model;
using Bullet.View;
using Weapons.Bullet;
using System;

namespace Bullet.Controller
{
    public class BulletController
    {

        private GameObject bulletInstance;
        private GameObject _bulletPrefab;
        private BulletModel currentBulletModel;
        private BulletView currentBulletView;


        protected PlayerController currentPlayerController;

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
        protected virtual BulletModel CreateModel()
        {
            return new BulletModel();
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
            currentPlayerController = BulletService.Instance.GetPlayerControllerInstance();
        }

        public void InvokeAction(ITakeDamage _currentView)
        {
            HasCollided.Invoke(_currentView,currentBulletModel.GetPointDamage());
        }
    }
}