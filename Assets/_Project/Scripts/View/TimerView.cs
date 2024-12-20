using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textTimer;
    [SerializeField]
    private GameObject _enble;

    private EventBus _bus;
    private bool _changed = false;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);
        _bus.Subscribe<FailedTaskSignal>(OnFailedTask);
        _bus.Subscribe<TerminalPickedAndClosedSignal>(OnTerminalClosed);
    }

    private void Update()
    {
        if (!_changed) return;
        _textTimer.text = Mathf.RoundToInt(ServiceLocator.Instance.Get<TaskTimer>().time).ToString();
    }

    private void OnNewTask(NewTaskSignal signal)
    {
        _changed = true;
    }

    private void OnTerminalClosed(TerminalPickedAndClosedSignal signal)
    {
        _enble.SetActive(true);
    }

    private void OnSuccessTask(SuccessTaskSignal signal)
    {
        _changed = false;
        _textTimer.text = "";
        _enble.SetActive(false);
    }

    private void OnFailedTask(FailedTaskSignal signal)
    {
        _changed = false;
        _textTimer.text = "";
        _enble.SetActive(false);
    }
}
