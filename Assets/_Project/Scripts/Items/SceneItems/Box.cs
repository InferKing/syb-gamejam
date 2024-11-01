using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    public bool CanInteract => throw new System.NotImplementedException();

    public void Action()
    {
        
    }
}
