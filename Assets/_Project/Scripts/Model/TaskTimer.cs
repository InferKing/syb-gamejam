using System.Collections;
using UnityEngine;

public class TaskTimer : MonoBehaviour
{
    private EventBus _bus;
    private NewTask _task;
    private Coroutine _timer;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);
    }

    private void OnNewTask(NewTaskSignal signal) 
    {
        _task = signal.task;
        _timer = StartCoroutine(Timer());
    }

    private void OnSuccessTask(SuccessTaskSignal signal)
    {
        _task = null;
        StopCoroutine(_timer);
        _timer = null;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_task.task.RoundTime);
        _bus.Invoke(new FailedTaskSignal(_task));
    }
}
