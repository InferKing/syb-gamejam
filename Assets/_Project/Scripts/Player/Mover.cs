using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
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

    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.sqrMagnitude);
        _animator.speed = Mathf.Clamp(_curve.Evaluate(_rigidbody.velocity.sqrMagnitude / 10), 1, 2);

        Vector3 rot = new(GetCorrectRotation(Input.GetAxisRaw(Horizontal)), 0, GetCorrectRotation(Input.GetAxisRaw(Vertical)));

        if (rot.magnitude > 0)
        {
            Rotate(rot);
        }
    }

    void FixedUpdate()
    {
        if (_isCanMove)
        {
            Vector3 move = new Vector3(Input.GetAxisRaw(Horizontal), 0, Input.GetAxisRaw(Vertical)).normalized;

            if (move.magnitude > 0)
            {
                if (_rigidbody.velocity.magnitude < 1f)
                {
                    _rigidbody.AddForce(move * _impulsePower, ForceMode.Impulse);
                }

                _rigidbody.AddForce(move * _moveSpeedFactor, ForceMode.Acceleration);
            }

            if (_rigidbody.velocity.magnitude > _maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
            }
        }
    }

    private int GetCorrectRotation(float value)
    {
        if (value < 0) return -1;
        else if (value > 0) return 1;
        return 0;
    }

    private void Rotate(Vector3 forward)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(forward), _rotationSpeed * Time.deltaTime);
    }

    private void StopMove(CantMoveSignal signal)
    {
        _isCanMove = false;
    }

    private void StartMove(CanMoveSignal signal)
    {
        _isCanMove = false;
    }
}

