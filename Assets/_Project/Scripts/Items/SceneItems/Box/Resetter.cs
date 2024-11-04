using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Resetter : MonoBehaviour
{
    private EventBus _bus;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Collider _collider;
    private Rigidbody _rb;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _bus.Subscribe<ResetSceneSignal>(OnResetScene);

        _rb = GetComponent<Rigidbody>();
    }

    public void ResetTransform()
    {
        if (TryGetComponent(out Collider collider))
        {
            collider.enabled = false;
        }

        transform.DOMove(_startPosition, 1f).OnComplete(() =>
        {
            if (collider != null)
            {
                collider.enabled = true;
                _rb.velocity = Vector3.zero;
            }
        });
        transform.DORotate(_startRotation.eulerAngles, 1f);
    }

    private void OnResetScene(ResetSceneSignal signal)
    {
        ResetTransform();
    }
}
