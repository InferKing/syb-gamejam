using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class BoxMover : MonoBehaviour
{
    [SerializeField] private PlayerInteractableFinder _player;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _runDistance;
    [SerializeField] private float _moveSpeedFactor;
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;

    private Vector3 _targetPosition;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _moveSpeedFactor;

        _targetPosition = _points[Random.Range(0, _points.Count)].position;
    }

    void Update()
    {
        if (_targetPosition == transform.position)
        {
            _targetPosition = _points[Random.Range(0, _points.Count)].position;
            _agent.SetDestination(_targetPosition);
            // вобщем возвращаемся к поинтам)
        }
    }
}
