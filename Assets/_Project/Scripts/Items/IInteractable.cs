using UnityEngine;

public interface IInteractable
{
    bool CanInteract { get; }
    Vector3 Position { get; }
    void Action();
}