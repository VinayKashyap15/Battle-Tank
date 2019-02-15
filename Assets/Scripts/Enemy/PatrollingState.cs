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

        public List<Vector3> patrolPoints = new List<Vector3>();
        Vector3 nextPatrolPoint;
        public void OnStateEnter()
        {
            spawnPosition = this.gameObject.transform.transform.localPosition;
            patrolPoints.Add(new Vector3(UnityEngine.Random.Range(-1, 10), 0, UnityEngine.Random.Range(-5, 10)));
            patrolPoints.Add(new Vector3(UnityEngine.Random.Range(-1, 10), 0, UnityEngine.Random.Range(-5, 10)));
            patrolPoints.Add(new Vector3(UnityEngine.Random.Range(-1, 10), 0, UnityEngine.Random.Range(-5, 10)));
            this.enabled = true;
            nextPatrolPoint = GetNewPoint();
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
            if (Vector3.Distance(this.gameObject.transform.localPosition, nextPatrolPoint) <= 0.5f)
            {
                nextPatrolPoint = GetNewPoint();
            }
            this.gameObject.transform.localPosition = Vector3.Lerp(this.gameObject.transform.localPosition, nextPatrolPoint, 0.1f*Time.deltaTime);
        }

        private Vector3 GetNewPoint()
        {
            Vector3 newPoint=patrolPoints.ElementAt(UnityEngine.Random.Range(0, patrolPoints.Count));
            if(newPoint!=nextPatrolPoint)
            return newPoint;
            else
            {
                return GetNewPoint();
            }
        }
    }
}