using UnityEngine;
using GameplayInterfaces;

namespace EnemyStates
{
    public class ChaseState : MonoBehaviour, IEnemyState
    {
        public Vector3 lastSeenPosition;

        private void OnEnable()
        {
            
        }
        public void OnStateEnter()
        {
            this.enabled = true;
        }

        public void OnStateExit()
        {
            this.enabled = false;
        }

        public void OnStateUpdate()
        {            
            this.gameObject.transform.localPosition=Vector3.Lerp(this.gameObject.transform.localPosition,lastSeenPosition,0.1f*Time.deltaTime);

            if(Vector3.Distance(this.gameObject.transform.localPosition,lastSeenPosition)<=1f)
            {
               Enemy.EnemyService.Instance.StopChasing();
            }

        }
    }
}