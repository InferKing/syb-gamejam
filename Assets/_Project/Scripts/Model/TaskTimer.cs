using System.Collections;
using UnityEngine;

public class TaskTimer : MonoBehaviour, IService
{
    private EventBus _bus;
    private NewTask _task;
    private Coroutine _timer;

    public float time = 0;

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
        time = _task.task.RoundTime;
        while (time >= 0)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _bus.Invoke(new FailedTaskSignal(_task));
    }
}
