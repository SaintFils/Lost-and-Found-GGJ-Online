using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProcessNamespace
{
    public class EnemyMove : MonoBehaviour
    {
        public Transform[] waypoints;
        private Moveable _moveable;
        private int index;
        public float patrolDistance;
        
        

        private void Start()
        {
            _moveable = GetComponent<Moveable>();
            index = 0;
        }

        private void Update()
        {
            patrolDistance = Vector3.Distance(transform.position, waypoints[index].position);
            if (patrolDistance < 1f)
            {
                IncreaseIndex();
            }
            _moveable.MoveToTarget(waypoints[index]);
           
           
            /*if (waypoints[index].position == transform.position)
            {
                index = (index + 1) % waypoints.Length;
                _moveable.MoveToTarget(waypoints[index]);
            }*/
            
        }

        private void IncreaseIndex()
        {
            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }
    }
}