public class FailedTaskSignal
{
    public readonly NewTask task;

    public FailedTaskSignal(NewTask task)
    {
        this.task = task;
    }
}
