using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField]
    private TerminalUI _ui;

    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    public void Action()
    {
        _ui.Open();
    }
}
