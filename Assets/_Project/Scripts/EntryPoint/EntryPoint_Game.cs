using Model.Characters;
using Model.Items;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AllItems : IService
{
    public readonly List<ItemData> items;
    public AllItems(List<ItemData> items)
    {
        this.items = items;
    }
}

public class AllPointToGo : IService
{
    public readonly List<Transform> points;
    public AllPointToGo(List<Transform> points) 
    { 
        this.points = points;
    }
}

public class EntryPoint_Game : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private List<ItemData> _items;
    [SerializeField]
    private List<Transform> _whereToGo;
    [SerializeField]
    private TaskTimer _taskTimer;

    private void Awake()
    {
        DOTween.Init();

        ServiceLocator.Initialize();
        ServiceLocator.Instance.Register(new EventBus());
        ServiceLocator.Instance.Register(_inputManager);
        ServiceLocator.Instance.Register(new AllItems(_items));
        ServiceLocator.Instance.Register(new PickedItems(ServiceLocator.Instance.Get<EventBus>()));
        ServiceLocator.Instance.Register(new GameModel(ServiceLocator.Instance.Get<EventBus>()));
        ServiceLocator.Instance.Register(new AllPointToGo(_whereToGo));
        ServiceLocator.Instance.Register(new TaskTimer());
    }
}
