using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeedFactor;
    [SerializeField] private float _impulsePower;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _delaySteps;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationCurve _curve;

    private bool _isCanMove;
    private EventBus _bus;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection = Vector3.zero;
    public float MoveSpeed => _moveSpeedFactor;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<CantMoveSignal>(StopMove);
        _bus.Subscribe<CanMoveSignal>(StartMove);
        _rigidbody = GetComponent<Rigidbody>();
        _isCanMove = true;
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw(Horizontal), 0, Input.GetAxisRaw(Vertical)).normalized;

        if (moveDirection.magnitude > 0)
        {
            if (_rigidbody.velocity.magnitude < 1f)
            {
                _rigidbody.AddForce(moveDirection * _impulsePower, ForceMode.Impulse);
            }

            _rigidbody.AddForce(moveDirection * _moveSpeedFactor, ForceMode.Acceleration);
            Rotate(moveDirection);
        }

        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }
    }

    private void Rotate(Vector3 forward)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(forward), _rotationSpeed);
    }

    private void StopMove(CantMoveSignal signal)
    {
        _isCanMove = false;
    }

    private void StartMove(CanMoveSignal signal)
    {
        _isCanMove = true;
    }

}
