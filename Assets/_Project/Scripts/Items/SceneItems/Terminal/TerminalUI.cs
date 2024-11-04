using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _root;
    [SerializeField]
    private List<TerminalTab> _tabs;
    [SerializeField]
    private List<Button> _buttons;
    [SerializeField]
    private AllItemsView _allItems;

    private NewTask _task;
    private bool _isCanClisk;
    public bool IsCanClisk => _isCanClisk;

    private void Start()
    {
        _buttons[0].onClick.AddListener(() => OpenTab(0));
        _buttons[1].onClick.AddListener(() => OpenTab(1));

        _allItems.Init();
    }

    public void Open()
    {
        _isCanClisk = true;

        GameModel model = ServiceLocator.Instance.Get<GameModel>();

        if (model.State == GameState.PickedInTerminal || model.State == GameState.GetAll)
        {
            return;
        }
        if (model.State == GameState.NewTask)
        {
            model.State = GameState.InTerminal;
            ServiceLocator.Instance.Get<EventBus>().Invoke(new GameStateChangedSignal(model.State));
        }
        _root.SetActive(true);

        OpenTab(0);

        ServiceLocator.Instance.Get<EventBus>().Invoke(new SetOnTerminalSignal());
        ServiceLocator.Instance.Get<EventBus>().Invoke(new CantMoveSignal());
    }

    public void SetCharacterInfo(NewTask task)
    {
        _task = task;
    }

    public void Close()
    {
        _isCanClisk = false;

        int pickedAmount = ServiceLocator.Instance.Get<PickedItems>().Items.Count;
        int taskAmount = ServiceLocator.Instance.Get<GameModel>().CurrentTask.task.MaxItems;
        GameModel model = ServiceLocator.Instance.Get<GameModel>();

        if (pickedAmount == taskAmount)
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new TerminalPickedAndClosedSignal());
        }
        if (pickedAmount != taskAmount && model.State == GameState.InTerminal)
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new NotEnoughPickedSignal());
            return;
        }
        // Проверка в каком состоянии вышел

        ServiceLocator.Instance.Get<EventBus>().Invoke(new CanMoveSignal());
        ServiceLocator.Instance.Get<EventBus>().Invoke(new SetOffTerminalSignal());
        _root.SetActive(false);
    }

    private void OpenTab(int index)
    {
        for (int i = 0; i < _tabs.Count; i++) 
        {
            _tabs[i].SetActiveTab(i == index, _task);
        }
        _allItems.Show();
    }
}
