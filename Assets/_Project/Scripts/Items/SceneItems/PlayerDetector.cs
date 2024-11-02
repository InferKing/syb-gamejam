using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public event Action PlayerNearby;

    private Transform _playerTransform;
    private bool _changedState = false;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerInteractableFinder>().transform;
    }

    public void ResetBlyat()
    {
        _changedState = false;
    }

    private void Update()
    {
        if (_changedState) return;
        if (Vector3.Distance(_playerTransform.position, transform.position) < 10f)
        {
            PlayerNearby?.Invoke();
            _changedState = true;
        }
    }
}
