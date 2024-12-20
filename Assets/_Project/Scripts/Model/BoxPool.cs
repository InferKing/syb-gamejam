using Model.Items;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    //TODO: �������� ����� ���������, rotation � �������� ������� � ������������ ���������
    [SerializeField]
    private List<Box> _boxes;

    private EventBus _bus;
    private NewTask _task;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<PlayerEnterTerminalSignal>(OnPlayerEnterTerminal);
        _bus.Subscribe<TerminalPickedAndClosedSignal>(OnTerminalClosed);
        _bus.Subscribe<ResetSceneSignal>(OnResetScene);
    }

    private void OnNewTask(NewTaskSignal signal)
    {
        _task = signal.task;
    }

    private List<int> GenerateIndexes()
    {
        List<int> randomIndexes = new();
        var items = _task.task.MaxItems;

        for (int i = 0; i < items; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, _boxes.Count);
            }
            while (randomIndexes.Contains(randomIndex));
            randomIndexes.Add(randomIndex);
        }

        return randomIndexes;
    }

    private void OnTerminalClosed(TerminalPickedAndClosedSignal signal)
    {
        List<int> randomIndexes = GenerateIndexes();

        for (int i = 0; i < randomIndexes.Count; i++) 
        {
            _boxes[randomIndexes[i]].SetItem(ServiceLocator.Instance.Get<PickedItems>().Items[i]);
        }
    }

    private void OnResetScene(ResetSceneSignal signal)
    {
        foreach (var item in _boxes)
        {
            item.ReplaceToStartPositionAndRotation();
        }
    }

    private void OnPlayerEnterTerminal(PlayerEnterTerminalSignal terminal)
    {
        foreach (var item in _boxes) 
        { 
            // ������ ����������� ������ ����� win/lose
            //item.ReplaceToStartPositionAndRotation();
        }
    }
}
