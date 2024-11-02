using UnityEngine;
using Model.Items;

public class Box : MonoBehaviour, IInteractable
{
    public bool CanInteract => true;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private ItemData _item;

    public Vector3 Position => transform.position;

    public void Action()
    {
        Debug.Log("Box blyat");
    }

    private void Start()
    {
        _startPosition = gameObject.transform.position;
        _startRotation = gameObject.transform.rotation;
    }

    public void ReplaceToStartPositionAndRotation()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }

    public void SetItem(ItemData item)
    {
        _item = item;
    }
}
