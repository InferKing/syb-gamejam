using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Podskaz : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private EventBus _bus;

    private Coroutine _coroutine;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<TerminalPickedAndClosedSignal>(OnPickedTerminal);
        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<GetItemInSceneSignal>(OnGetItems);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccess);
        _bus.Subscribe<FailedTaskSignal>(OnFailed);
    }

    void OnPickedTerminal(TerminalPickedAndClosedSignal signal)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(TypeText("Найдите все вещи, которые спрятались в коробках."));
    }

    void OnFailed(FailedTaskSignal signal)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(TypeText("Вы опоздали."));
    }

    void OnSuccess(SuccessTaskSignal signal)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(TypeText("Вы успели."));
    }

    void OnNewTask(NewTaskSignal signal)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        StartCoroutine(TypeText("У вас появилось новое задание, подойдите к терминалу. "));
    }

    void OnGetItems(GetItemInSceneSignal signal)
    {
        if (ServiceLocator.Instance.Get<GameModel>().State == GameState.GetAll)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            StartCoroutine(TypeText("Подойдите к пневмопочте для отправки предметов герою."));
        }
    }

    IEnumerator TypeText(string text)
    {
        _text.text = "";
        foreach (var item in text) 
        {
            _text.text += item;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
