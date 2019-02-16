using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameplayInterfaces;
using System;

namespace EnemyStates
{
    public class PatrollingState : MonoBehaviour, IEnemyState
    {
        private Vector3 spawnPosition;
        private bool isPaused=false;
        public List<Vector3> patrolPoints = new List<Vector3>();
        Vector3 nextPatrolPoint;
        Vector3 pointA,pointB;

        private void Start()
        {
            StateMachineImplementation.StateMachineService.Instance.OnPause+=OnPause;
            spawnPosition = this.gameObject.transform.transform.localPosition;
            
            pointA=spawnPosition+new Vector3(10,0,0);
            pointB = spawnPosition+ new Vector3(-10,0,0);

            nextPatrolPoint=pointA;
        }
        private void Update() {
            OnStateUpdate();
        }
        public void OnStateEnter()
        {

            // patrolPoints.Add(new Vector3(UnityEngine.Random.Range(-1, 10), 0, UnityEngine.Random.Range(-5, 10)));
            // patrolPoints.Add(new Vector3(UnityEngine.Random.Range(-1, 10), 0, UnityEngine.Random.Range(-5, 10)));
            // patrolPoints.Add(new Vector3(UnityEngine.Random.Range(-1, 10), 0, UnityEngine.Random.Range(-5, 10)));
            //nextPatrolPoint = GetNewPoint();

            this.enabled = true;
        }

        private void OnEnable()
        {
            
        }

        public void OnStateExit()
        {         
            this.enabled = false;
        }

        public void OnStateUpdate()
        {
            // if (Vector3.Distance(this.gameObject.transform.localPosition, nextPatrolPoint) <= 0.5f)
            // {
            //     nextPatrolPoint = GetNewPoint();
            // }
           if(isPaused)
           {
               return;
           }
            if(Vector3.Distance(this.gameObject.transform.localPosition,nextPatrolPoint)<=0.5f)
            {
               nextPatrolPoint=GetNewPoint();
            }            
            this.gameObject.transform.localPosition = Vector3.Lerp(this.gameObject.transform.localPosition, nextPatrolPoint, 0.4f*Time.deltaTime);
        }

        private Vector3 GetNewPoint()
        {
            // Vector3 newPoint=patrolPoints.ElementAt(UnityEngine.Random.Range(0, patrolPoints.Count));
            // if(newPoint!=nextPatrolPoint)
            // return newPoint;
            // else
            // {
            //     return GetNewPoint();
            // }

            Vector3 newPoint= pointB;
            if(nextPatrolPoint==newPoint)
            {
                newPoint=pointA;
            }

            return newPoint;
        }

        public void OnPause()
        {
            isPaused=!isPaused;
        }
    }
}