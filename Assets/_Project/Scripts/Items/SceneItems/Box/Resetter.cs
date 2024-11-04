using DG.Tweening;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    private EventBus _bus;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Collider _collider;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _bus.Subscribe<ResetSceneSignal>(OnResetScene);


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
            }
        });
        transform.DORotate(_startRotation.eulerAngles, 1f);
    }

    private void OnResetScene(ResetSceneSignal signal)
    {
        ResetTransform();
    }
}
