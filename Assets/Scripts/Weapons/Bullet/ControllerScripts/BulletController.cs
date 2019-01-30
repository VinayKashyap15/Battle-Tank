using UnityEngine;
using Bullet.ModelScripts;
using Bullet.ViewScripts;

namespace Bullet.ControllerScripts
{
    public class BulletController
    {

        private GameObject bulletPrefab;
        private BulletModel currentBulletModel;

        public BulletController()
        {
            currentBulletModel = CreateModel();
            if (!bulletPrefab)
            {
                GameObject _bulletPrefab = Resources.Load("Bullet") as GameObject;

                bulletPrefab = GameObject.Instantiate(_bulletPrefab);
            }
            BulletView bulletView = bulletPrefab.GetComponent<BulletView>();
            bulletView.SetController(this);
        }

        protected virtual BulletModel CreateModel()
        {
            return new BulletModel();
        }

        public GameObject GetBullet()
        {
            return bulletPrefab;
        }

        public float GetBulletSpeed()
        {
            return currentBulletModel.GetBulletSpeed();
        }

        public virtual void StartDestroy()
        {
            currentBulletModel = null;
        }
    }
}