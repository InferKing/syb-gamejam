using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    public bool CanInteract => throw new System.NotImplementedException();

    public void Action()
    {
        
    }
}
