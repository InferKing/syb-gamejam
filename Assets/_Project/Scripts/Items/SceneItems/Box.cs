using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    public void Action()
    {
        Debug.Log("Box blyat");
    }
}