using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private PlayerAnimationController _animator;

    private Rigidbody _rigidbody;
    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw(Horizontal), 0, Input.GetAxisRaw(Vertical)).normalized;

        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            JoyStickMove(direction);
        }
    }

    public void JoyStickMove(Vector3 direction)
    {
        Vector3 distance = direction * _moveSpeed * Time.deltaTime;
        Vector3 nextPosition = transform.position + distance;

        if (direction != Vector3.zero)
        {
            Rotate(direction);
        }

        transform.position = transform.position + distance;

        _animator.DoMove(direction.magnitude);
    }

    private void Rotate(Vector3 forward)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(forward), _rotationSpeed);
    }
}

