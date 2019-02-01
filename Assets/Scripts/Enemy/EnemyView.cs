using Common;
using UnityEngine;
namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyView : MonoBehaviour
    {
        private EnemyController currentEnemyController;


        public void SetController(EnemyController _enemyController)
        {
            currentEnemyController = _enemyController;
        }

        protected virtual void DestroySelf()
        {
            EnemyService.Instance.DestroyController(currentEnemyController);

            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
     
            if (collision.collider.CompareTag("Bullet"))
            {
                //destroy self when bullet collides. Take Damage Functionality would be added at later stage
                DestroySelf();
            }
        }
        

        public void SetMaterial(Material _newMat)
        {
            this.GetComponentInChildren<Renderer>().sharedMaterial = _newMat;
        }
    }
}