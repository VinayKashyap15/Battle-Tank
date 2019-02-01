using UnityEngine;

namespace Bullet.Model  
{
    public class BulletModel
    {
        private float pointDamage;
        protected  float bulletSpeed;
        private float bulletLife;
        private Vector3 bulletPosition;
        private float fireRate;

        public BulletModel()
        {
            pointDamage = 10f;
            bulletSpeed = 5f;
            bulletLife = 3f;
            bulletPosition = new Vector3(0, 0, 1);
            fireRate = 5f;
        }
        public float GetPointDamage()
        {
            return pointDamage;
        }

        public virtual float GetBulletSpeed()
        {
            return bulletSpeed;
        }

        public float GetBulletLife()
        {
            return bulletLife;
        }

        public Vector3 GetBulletPosition()
        {
            return bulletPosition;
        }
        public float GetFireRate()
        {
            return fireRate;
        }

        protected virtual void UpdateDamage(float pointDamage) { }
        protected virtual void UpdateSpeed(float bulletSpeed) { }
    }
}