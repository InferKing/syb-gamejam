using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    public void Action()
    {
        Debug.Log("Terminal blyat");
    }
}
