using Model.Items;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    //TODO: ƒобавить сброс положени€, rotation и анимации коробок к стандратному состо€нию
    [SerializeField]
    private List<ItemData> _items;
    [SerializeField]
    private List<Box> _boxes;

    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<NewTaskSignal>(OnNewTask);
        _bus.Subscribe<PlayerEnterTerminal>(OnPlayerEnterTerminal);
    }

    private void OnNewTask(NewTaskSignal signal)
    {
        List<int> randomIndexes = new();
        var items = signal.task.task.Items;

        for (int i = 0; i < items.Count; i++) 
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, _items.Count);
            }
            while (randomIndexes.Contains(randomIndex));
            randomIndexes.Add(randomIndex);
        }

        foreach (var index in randomIndexes)
        {
            // указать предметы, которые выбрал пользователь!
            //_boxes[index].SetItem()
        }
    }

    private void OnPlayerEnterTerminal(PlayerEnterTerminal terminal)
    {
        foreach (var item in _boxes) 
        { 
            item.ReplaceToStartPositionAndRotation();
        }
    }
}
