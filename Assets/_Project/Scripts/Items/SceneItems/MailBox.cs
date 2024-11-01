using UnityEngine;

public class MailBox : MonoBehaviour, IInteractable
{
    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    public void Action()
    {
        Debug.Log("MailBox blyat");
    }
}
