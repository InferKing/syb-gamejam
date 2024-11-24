using Model.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// основной цикл событий игры
public class GameController : MonoBehaviour
{
    [SerializeField]
    private TaskManager _taskManager;

    private bool _hasTask = false;
    private EventBus _bus;
    private WaitForSeconds _delay3 = new(3);
    private WaitForSeconds _delay10 = new(10);
    private Coroutine _coroutine;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<FailedTaskSignal>(OnFailedTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);

        StartCoroutine(Delay(1f));
    }

    public void FindTask()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        NewTask task = _taskManager.GetNewTaskLimited();

        if (task == null)
        {
            Debug.Log("Здесь конец игры");
            return;
        }

        _hasTask = true;
        _bus?.Invoke(new NewTaskSignal(task));
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);  
        FindTask();
    }

    private IEnumerator GameCycle()
    {
        yield return _delay3;
        while (true)
        {
            if (_hasTask)
            {
                yield return null;
                continue;
            }

            if (ServiceLocator.Instance.Get<GameModel>().State != GameState.Idle)
            {
                yield return null;
                continue;
            }

            yield return _delay10;
        }
    }

    private void OnFailedTask(FailedTaskSignal signal)
    {
        ServiceLocator.Instance.Get<GameModel>().resultTasks[signal.task] = false;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(Delay(3f));
    }

    private void OnSuccessTask(SuccessTaskSignal signal)
    {
        ServiceLocator.Instance.Get<GameModel>().resultTasks[signal.task] = true;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        _coroutine = StartCoroutine(Delay(3f));
    }
}
