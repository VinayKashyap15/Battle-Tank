using UnityEngine;
using Enemy;
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
           
            StateMachineImplementation.StateMachineService.Instance.OnPause += PauseBullet;
            StateMachineImplementation.StateMachineService.Instance.OnResume += ResumeBullet;
        }
    
        public void SetController(BulletController _bulletController)
        {
            currentBulletController = _bulletController;
        }

        protected virtual void DestroyBullet()
        {
            BulletService.Instance.DestroyController(currentBulletController);

            Destroy(this.gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<ITakeDamage>() != null)
            {
                currentBulletController.InvokeAction(collision.collider.gameObject.GetComponent<ITakeDamage>());
            }
            DestroyBullet();

        }

        public void FireBullet(GameObject bulletInstance, Vector3 _firePosition, Quaternion _fireRotation, Vector3 _fireDirection, float _bulletSpeed)
        {

            bulletInstance.transform.position = _firePosition;
            bulletInstance.transform.rotation = _fireRotation;
            rb=bulletInstance.GetComponent<Rigidbody>();
            bulletInstance.GetComponent<Rigidbody>().velocity = _fireDirection * _bulletSpeed;
            velocity=bulletInstance.GetComponent<Rigidbody>().velocity;
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
    }
}