using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BoxMover : MonoBehaviour
{
    private const float Radius = 15f;

    [SerializeField]
    private NavMeshAgent _agent;

    private List<Transform> _whereToGo;
    private Coroutine _coroutine;
    private PlayerInteractableFinder _interactableFinder;
    private Vector3 _targetPosition;

    public void MoveAway()
    {
        _whereToGo = ServiceLocator.Instance.Get<AllPointToGo>().points;
        _interactableFinder = FindObjectOfType<PlayerInteractableFinder>();
        _coroutine = StartCoroutine(AvoidPlayer());
    }

    public void Stop()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator AvoidPlayer()
    {
        _targetPosition = FindFarthestPointInRadius(_whereToGo, _interactableFinder.transform.position, Radius);
        while (true)
        {
            if (Vector3.Distance(_targetPosition, _agent.transform.position) < 1f)
            {
                _targetPosition = FindFarthestPointInRadius(_whereToGo, _interactableFinder.transform.position, Radius);
            }
            _agent.SetDestination(_targetPosition);
            yield return null;
        }
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
