using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeedFactor;
    [SerializeField] private float _magnitude;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private PlayerAnimationController _animator;

    private Rigidbody _rigidbody;
    public float MoveSpeed => _moveSpeedFactor;
    public float Magnitude => _magnitude;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //var moveDirection = (Input.GetAxis("Horizontal") * transform.TransformDirection(Vector3.right) + Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward)).normalized;
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw(Horizontal), 0, Input.GetAxisRaw(Vertical)).normalized;

        if (moveDirection.magnitude > 0)
        {
            _rigidbody.AddForce(moveDirection * _moveSpeedFactor, ForceMode.Acceleration);
            Rotate(moveDirection);
            _magnitude = _rigidbody.velocity.magnitude;
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

