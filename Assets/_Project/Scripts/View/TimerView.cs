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
}
