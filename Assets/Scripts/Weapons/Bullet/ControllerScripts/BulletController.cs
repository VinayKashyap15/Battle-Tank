using UnityEngine;
using Common;
using Player;
using Bullet.Model;
using Bullet.View;
using Weapons.Bullet;

namespace Bullet.Controller
{
    public class BulletController
    {

        private GameObject bulletInstance;
        private GameObject _bulletPrefab;
        private BulletModel currentBulletModel;
        private BulletView currentBulletView;


        protected PlayerController currentPlayerController;

        public BulletController()
        {    
            currentBulletModel = CreateModel();
            if (!_bulletPrefab)
            {
                _bulletPrefab = Resources.Load("Bullet") as GameObject;
            }

            bulletInstance = GameObject.Instantiate(_bulletPrefab);
            BulletView bulletView = bulletInstance.GetComponent<BulletView>();
            bulletView.SetController(this);
            SetPlayerControllerInstance();
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

        public virtual void StartDestroy()
        {
            currentBulletModel = null;
        }

        public void FireBullet(Vector3 _firePosition, Quaternion _fireRotation, Vector3 _fireDirection)
        {
            currentBulletView.FireBullet(bulletInstance, _firePosition,  _fireRotation,  _fireDirection,GetBulletSpeed());
           
        }

        public virtual void SetPlayerControllerInstance()
        {
            currentPlayerController = PlayerService.Instance.GetPlayerControllerInstance();
        }

        public void UpdateScore()
        {
            currentPlayerController.UpdateScore();
        }
    }
}