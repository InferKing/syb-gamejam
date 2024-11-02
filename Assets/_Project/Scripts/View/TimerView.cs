using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textTimer;

    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<NewTaskSignal>(OnNewTask);
    }

    private void OnNewTask(NewTaskSignal signal)
    {

    }
}
