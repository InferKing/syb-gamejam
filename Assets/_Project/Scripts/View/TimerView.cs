using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textTimer;

    private EventBus _bus;
    private bool _changed = false;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);
        _bus.Subscribe<FailedTaskSignal>(OnFailedTask);
    }

    private void Update()
    {
        if (!_changed) return;
        _textTimer.text = $"Оставшееся время: {Mathf.RoundToInt(ServiceLocator.Instance.Get<TaskTimer>().time)} секунд";
    }

    private void OnNewTask(NewTaskSignal signal)
    {
        _changed = true;
    }

    private void OnSuccessTask(SuccessTaskSignal signal)
    {
        _changed = false;
        _textTimer.text = "";
    }

    private void OnFailedTask(FailedTaskSignal signal)
    {
        _changed = false;
        _textTimer.text = "";
    }
}
