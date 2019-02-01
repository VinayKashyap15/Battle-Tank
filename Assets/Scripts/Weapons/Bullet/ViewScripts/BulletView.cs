using UnityEngine;
using Weapons.Bullet;
using Bullet.Controller;
using System;

namespace Bullet.View
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class BulletView : MonoBehaviour
    {
        private BulletController currentBulletController;
       

        public void SetController(BulletController _bulletController)
        {
            currentBulletController = _bulletController;
        }
        protected virtual void SetMaterial()
        {
        }
        protected virtual void DestroyBullet()
        {
            BulletService.Instance.DestroyController(currentBulletController);

            Destroy(this.gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag("Enemy"))
            {
                currentBulletController.UpdateScore();
            }
            DestroyBullet();

        }

        public void FireBullet(GameObject bulletInstance, Vector3 _firePosition, Quaternion _fireRotation, Vector3 _fireDirection, float _bulletSpeed)
        {              

                bulletInstance.transform.position = _firePosition;
                bulletInstance.transform.rotation = _fireRotation;
                bulletInstance.GetComponent<Rigidbody>().velocity = _fireDirection * _bulletSpeed;
            
        }
    }
}