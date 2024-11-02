using UnityEngine;
using UnityEngine.AI;

public class BoxMover : MonoBehaviour
{
    [SerializeField] private PlayerInteractableFinder _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _runDistance;
    [SerializeField] private float _moveSpeedFactor;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _moveSpeedFactor;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (distanceToPlayer < _runDistance)
        {
            Flee();
        }
    }

    void Flee()
    {
        Vector3 directionToPlayer = transform.position - _player.transform.position;
        Vector3 fleeTarget = transform.position + directionToPlayer.normalized * _runDistance;

        agent.SetDestination(fleeTarget);
    }

}
