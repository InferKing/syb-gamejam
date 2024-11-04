using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BoxMover : MonoBehaviour
{
    private const float Radius = 20f;

    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private Rigidbody _rb;

    private List<Transform> _whereToGo;
    private Coroutine _coroutine;
    private PlayerInteractableFinder _interactableFinder;
    private Vector3 _targetPosition;
    private float _moveSpeed;

    public void MoveAway()
    {
        _whereToGo = ServiceLocator.Instance.Get<AllPointToGo>().points;
        _interactableFinder = FindObjectOfType<PlayerInteractableFinder>();
        _coroutine = StartCoroutine(AvoidPlayer());
        _agent.enabled = true;
        StartCoroutine(Boost());
    }

    public void Stop()
    {
        StopAllCoroutines();
        _rb.mass = _rb.mass / 5f;
        _agent.speed = _moveSpeed;
        _agent.enabled = false;
    }

    private IEnumerator AvoidPlayer()
    {
        _targetPosition = FindFarthestPointInRadius(_whereToGo, _interactableFinder.transform.position, Radius);
        while (true)
        {
            if (Vector3.Distance(_targetPosition, _agent.transform.position) < 2f)
            {
                _targetPosition = FindFarthestPointInRadius(_whereToGo, _interactableFinder.transform.position, Radius);
            }
            if (_agent.enabled)
            {
                _agent.SetDestination(_targetPosition);
            }
            yield return null;
        }
    }

    private IEnumerator Boost()
    {
        _moveSpeed = _agent.speed;
        _agent.speed = _moveSpeed * 4f;
        _rb.mass =  _rb.mass * 5;

        yield return new WaitForSeconds(2f);
        _agent.speed = _moveSpeed;
    }

    private Vector3 FindFarthestPointInRadius(List<Transform> points, Vector3 playerPos, float radius)
    {
        Transform farthestPoint = points
            .Where(point => Vector3.Distance(point.position, transform.position) <= radius)
            .OrderByDescending(point => Vector3.Distance(point.position, playerPos))
            .FirstOrDefault();

        return farthestPoint.position;
    }
}
