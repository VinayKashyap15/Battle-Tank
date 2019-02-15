using UnityEngine;
using GameplayInterfaces;

namespace EnemyStates
{
    public class ChaseState : MonoBehaviour, IEnemyState
    {
        private Vector3 lastSeenPosition;
        public ChaseState(Vector3 position)
        {
            lastSeenPosition=position;
        }

        private void OnEnable()
        {
            OnStateUpdate();
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
            Vector3 posToReach= Vector3.MoveTowards(this.gameObject.transform.localPosition, lastSeenPosition, 10f);
            this.gameObject.transform.localPosition=Vector3.Lerp(this.gameObject.transform.localPosition,posToReach,0.1f);

        }
    }
}