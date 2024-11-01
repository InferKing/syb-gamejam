using UnityEngine;

public class ItemBox : MonoBehaviour, IInteractable
{
    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    public void Action()
    {
        Debug.Log("ItemBox blyat");
    }
}
