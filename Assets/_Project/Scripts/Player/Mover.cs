using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeedFactor;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private PlayerAnimationController _animator;
    [SerializeField] private CharacterController _controller;

    private float _gravity = 20f;
    private Rigidbody _rigidbody;
    public float MoveSpeed => _moveSpeedFactor;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var moveDirection = (Input.GetAxis("Horizontal") * transform.TransformDirection(Vector3.right) + Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward)).normalized;

        if (moveDirection.magnitude > 0)
        {
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
}

