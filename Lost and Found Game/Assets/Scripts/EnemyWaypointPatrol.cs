using UnityEngine;
using UnityEngine.AI;

namespace ProcessNamespace
{
    public class EnemyWaypointPatrol : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private Transform _player;
        [SerializeField] private LayerMask _mask;

        private RaycastHit hit;
        private bool isPatrol = true;
        private int _currentWaypointIndex = 0;

        private void Awake()
        {
            _player = GameObject.FindObjectOfType<PlayerInput>().transform;
        }

        private void Start()
        {
            _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            _navMeshAgent.speed = Random.Range(1.0f, 2.0f);
        }

        private void FixedUpdate()
        {
            Color raycastLineColor = Color.red;

            Vector3 startPosition = CalculateOffset(transform.position, 0.7f);
            Vector3 directionRaycast = CalculateOffset(_player.position, 0.7f) - startPosition;

            var raycast = Physics.Raycast(startPosition, directionRaycast, out hit, directionRaycast.magnitude, _mask);

            if (raycast)
            {
                if (hit.transform.GetComponent<PlayerInput>())
                {
                    raycastLineColor = Color.green;
                    FollowTarget();
                }
                else
                {
                    Comeback();
                }
            }

            Debug.DrawLine(startPosition, CalculateOffset(_player.position, 0.5f), raycastLineColor);
        }

 

        public void SetWaypoint(Transform[] wayPoints)
        {
            _waypoints = wayPoints;
        }

        private Vector3 CalculateOffset(Vector3 position, float offsetY, float offsetZ = 0f)
        {
            position.y += offsetY;
            position.z += offsetZ;
            return position;
        }

        private void Comeback()
        {
            if (isPatrol && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            }
            else if (!isPatrol)
            {
                Wait();
                Invoke(nameof(Go), 1.5f);
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
                isPatrol = true;
            }
        }

        private void FollowTarget()
        {
            isPatrol = false;
            _navMeshAgent.SetDestination(_player.position);
        }

        private void Wait()
        {
            _navMeshAgent.isStopped = true;
        }

        private void Go()
        {
            _navMeshAgent.isStopped = false;
        }
    }
}