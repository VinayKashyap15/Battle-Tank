using UnityEngine;
using Common;
using Player;
using Bullet.ModelScripts;
using Bullet.ViewScripts;
using Weapons.Bullet;

namespace Bullet.ControllerScripts
{
    public class BulletController
    {

        private GameObject bulletInstance;
        private GameObject _bulletPrefab;
        private BulletModel currentBulletModel;
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
            bulletInstance.transform.position = _firePosition;
            bulletInstance.transform.rotation = _fireRotation;
            bulletInstance.GetComponent<Rigidbody>().velocity = _fireDirection * GetBulletSpeed();
        }

        public virtual void SetPlayerControllerInstance()
        {
            currentPlayerController = BulletService.Instance.GetPlayerControllerInstance();
        }

        public void UpdateScore()
        {
            ScoreManager.Instance.UpdateScore(currentPlayerController);
        }
    }
}