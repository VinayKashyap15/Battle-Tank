using System;
using UnityEngine;
using GameplayInterfaces;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyView : MonoBehaviour,ITakeDamage
    {
        private EnemyController currentEnemyController;


        public void SetController(EnemyController _enemyController)
        {
            currentEnemyController = _enemyController;
        }
        public EnemyController GetController()
        {
            return currentEnemyController;
        }

        public void DestroySelf()
        {     
            Destroy(this.gameObject);
        }

        public void SetMaterial(Material _newMat)
        {
            this.GetComponentInChildren<Renderer>().sharedMaterial = _newMat;
        }

        public Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }

        public void TakeDamage(int _damage)
        {
            currentEnemyController.DamageEnemy(_damage);
        }

        public string GetName()
        {
            return "EnemyView";
        }
    }
}