using UnityEngine;
using Enemy;
using ServiceLocator;
using GameplayInterfaces;
using Weapons.Bullet;
using Weapons.Interfaces;
using Bullet.Controller;
using System;

namespace Bullet.View
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class BulletView : MonoBehaviour
    {
        public Rigidbody rb;
        public Vector3 velocity;
        private BulletController currentBulletController;
        private void Start()
        {
           
            GameApplication.Instance.GetService<IStateMachineService>().OnPause += PauseBullet;
            GameApplication.Instance.GetService<IStateMachineService>().OnResume += ResumeBullet;
            
        }
    
        public void SetController(BulletController _bulletController)
        {
            currentBulletController = _bulletController;
        }

        protected virtual void DestroyBulletView()
        {
            GameApplication.Instance.GetService<IBulletService>().DestroyController(currentBulletController);

            Destroy(this.gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<ITakeDamage>() != null)
            {
                currentBulletController.InvokeAction(collision.collider.gameObject.GetComponent<ITakeDamage>());
            }
           // DestroyBulletView();
            DisableBulletView();

        }

        public void SetOriginalVelocity()
        {
           // this.rb.velocity=velocity;
        }

        protected virtual void DisableBulletView()
        {
            GameApplication.Instance.GetService<IBulletService>().DisableController(currentBulletController);
            
        }

        public void FireBullet(GameObject bulletInstance, Vector3 _firePosition, Quaternion _fireRotation, Vector3 _fireDirection, float _bulletSpeed)
        {
            
            bulletInstance.transform.position = _firePosition;
            bulletInstance.transform.rotation = _fireRotation;      
            rb=bulletInstance.GetComponent<Rigidbody>();     
            rb.angularVelocity= Vector3.zero;
            rb.velocity = _fireDirection * _bulletSpeed;
            velocity=rb.velocity;
        }

        public void PauseBullet()
        {
            if (rb != null)
            {
                rb.isKinematic = true;
            }

        }
        public void ResumeBullet()
        {
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity=velocity;
            }
        }

        public void Reset()
        {
            this.rb.velocity=Vector3.zero;
            this.gameObject.SetActive(false);
        }
    }
}