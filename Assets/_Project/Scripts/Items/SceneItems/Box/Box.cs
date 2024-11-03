using UnityEngine;
using Model.Items;
using DG.Tweening;

[ RequireComponent(typeof(Rigidbody))]
[ RequireComponent(typeof(Collider))]
public class Box : MonoBehaviour, IInteractable
{
    [SerializeField]
    private LayerMask _baseMask;
    [SerializeField]
    private LayerMask _usedMask;
    [SerializeField]
    private BoxMover _boxMover;
    [SerializeField]
    private BoxAnimation _boxAnimation;
    [SerializeField]
    private WorldSpacePickup _pickupPrefab;

    public bool CanInteract { get; private set; } = true;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private ItemData _item;
    private PlayerDetector _playerDetector;
    private Rigidbody _rigidBody;

    public Vector3 Position => transform.position;

    public void Action()
    {
        _boxMover.Stop();
        _boxAnimation.Play();

        var pickup = Instantiate(_pickupPrefab);
        pickup.PlayAnimation(_item, transform.position);
        CanInteract = false;
        _rigidBody = GetComponent<Rigidbody>();
        ServiceLocator.Instance.Get<EventBus>().Invoke(new GetItemInSceneSignal(_item));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor) || collision.gameObject.TryGetComponent(out PlayerInteractableFinder finder))
        {
            if (_rigidBody.velocity.magnitude > 0.3f)
            {
                ServiceLocator.Instance.Get<EventBus>().Invoke(new BoxFallSoundSignal());
            }
        }
    }

    private void Start()
    {
        _startPosition = gameObject.transform.position;
        _startRotation = gameObject.transform.rotation;
    }

    public void ReplaceToStartPositionAndRotation()
    {
        if (_playerDetector != null) 
        { 
            _playerDetector.enabled = false;
            gameObject.layer = GetIndexOfLayer(_baseMask);
        }
        transform.DOMove(_startPosition, 1f);
        transform.DORotate(_startRotation.eulerAngles, 1f);
        _item = null;

        _boxAnimation.ResetSides();
        CanInteract = true;
    }

    public void SetItem(ItemData item)
    {
        _item = item;
        if (_playerDetector == null)
        {
            _playerDetector = gameObject.AddComponent<PlayerDetector>();
            _playerDetector.PlayerNearby += OnPlayerNearby;
        }
        else
        {
            _playerDetector.ResetBlyat();
            _playerDetector.enabled = true;
        }
        gameObject.layer = GetIndexOfLayer(_usedMask);
    }

    private int GetIndexOfLayer(LayerMask mask)
    {
        return Mathf.RoundToInt(Mathf.Log(mask.value, 2));
    }

    private void OnPlayerNearby()
    {
        _boxMover.MoveAway();
    }
}
