public class GameModel : IService
{
    private EventBus _bus;

    public GameModel(EventBus bus)
    {
        _bus = bus;

        _bus.Subscribe<NewTaskSignal>(OnNewTask);
    }

    public NewTask CurrentTask { get; private set; }
    
    private void OnNewTask(NewTaskSignal signal)
    {
        CurrentTask = signal.task;
    }
}
