using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField]
    private TerminalUI _ui;
    private EventBus _bus;
    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<NewTaskSignal>(OnNewTask);
    }

    public void Action()
    {
        _ui.Open();
    }

    private void OnNewTask(NewTaskSignal signal)
    {
        _ui.SetCharacterInfo(signal.task);
    }
}
