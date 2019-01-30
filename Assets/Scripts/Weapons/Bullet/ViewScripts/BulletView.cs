using UnityEngine;
using Weapons.Bullet;
using Bullet.ControllerScripts;

namespace Bullet.ViewScripts
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
            BulletService.Instance.DestroyOldModels(currentBulletController);

            Destroy(this.gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            DestroyBullet();

        }
    }
}