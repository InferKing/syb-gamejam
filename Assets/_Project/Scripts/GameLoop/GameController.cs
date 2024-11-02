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
    private GameState _gameState = GameState.Idle;
    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<FailedTaskSignal>(OnFailedTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);

        StartCoroutine(GameCycle());
    }

    private IEnumerator GameCycle()
    {
        WaitForSeconds _delay3 = new(3);
        WaitForSeconds _delay10 = new(10);
        yield return _delay3;
        while (true)
        {
            if (_hasTask)
            {
                yield return _delay10;
                continue;
            }

            NewTask task = _taskManager.GetNewTask();
            _hasTask = true;
            _bus?.Invoke(new NewTaskSignal(task));

            yield return null;
        }
    }

    private void OnFailedTask(FailedTaskSignal signal)
    {
        _hasTask = false;
    }

    private void OnSuccessTask(SuccessTaskSignal signal)
    {
        _hasTask = false;
    }
}
