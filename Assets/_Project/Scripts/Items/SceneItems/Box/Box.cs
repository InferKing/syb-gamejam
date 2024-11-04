using UnityEngine;
using Model.Items;
using DG.Tweening;

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
    private ItemData _item;
    private PlayerDetector _playerDetector;

    public Vector3 Position => transform.position;

    public void Action()
    {
        _boxMover.Stop();
        _boxAnimation.Play();

        var pickup = Instantiate(_pickupPrefab);
        pickup.PlayAnimation(_item, transform.position);
        CanInteract = false;

        ServiceLocator.Instance.Get<EventBus>().Invoke(new GetItemInSceneSignal(_item));
    }

    public void ReplaceToStartPositionAndRotation()
    {
        if (_playerDetector != null) 
        { 
            _playerDetector.enabled = false;
            gameObject.layer = GetIndexOfLayer(_baseMask);
        }
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
