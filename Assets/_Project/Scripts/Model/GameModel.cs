public class GameModel : IService
{
    private EventBus _bus;

    public GameModel(EventBus bus)
    {
        _bus = bus;

        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<TerminalPickedAndClosedSignal>(OnTerminalClosed);
        _bus.Subscribe<GetItemInSceneSignal>(OnGetItem);
    }

    public NewTask CurrentTask { get; private set; }
    public GameState State { get; private set; } = GameState.Idle;
    
    private void OnNewTask(NewTaskSignal signal)
    {
        CurrentTask = signal.task;
        State = GameState.NewTask;
    }

    private void OnTerminalClosed(TerminalPickedAndClosedSignal signal)
    {
        if (State == GameState.InTerminal)
        {
            State = GameState.PickedInTerminal;
        }
    }

    private void OnGetItem(GetItemInSceneSignal signal)
    {
        if (CurrentTask.task.Items.Count == ServiceLocator.Instance.Get<PickedItems>().PlayerPickedItems.Count)
        {
            State = GameState.GetAll;
        }
    }
}
