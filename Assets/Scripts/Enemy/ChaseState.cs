using UnityEngine;
using GameplayInterfaces;

namespace EnemyStates
{
    public class ChaseState : MonoBehaviour, IEnemyState
    {
        public Vector3 lastSeenPosition;

        Enemy.EnemyView currentView;
        private bool isPaused=false;

        private void Start() {
            StateMachineImplementation.StateMachineService.Instance.OnPause+=OnPause;
            currentView= GetComponent<Enemy.EnemyView>();
        }
        private void Update() {
            OnStateUpdate();
        }
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
            if(isPaused)
            {
                return;
            }
            this.gameObject.transform.localPosition=Vector3.Lerp(this.gameObject.transform.localPosition,lastSeenPosition,0.1f*Time.deltaTime);

            if(Vector3.Distance(this.gameObject.transform.localPosition,lastSeenPosition)<=2f)
            {
               currentView.StopChasing();
            }

        }
        public void OnPause()
        {
            isPaused=!isPaused;
        }
    }
}