using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Model.Items;
using UnityEngine.UI;

public class ShowTasksPls : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textPrefab;
    [SerializeField]
    private VerticalLayoutGroup _group;

    private Dictionary<ItemData, TMP_Text> _matchText = new();
    private EventBus _bus;

    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();

        _bus.Subscribe<TerminalPickedAndClosedSignal>(OnTerminalClosed);
        _bus.Subscribe<GetItemInSceneSignal>(OnGetItem, 1);
        _bus.Subscribe<GameStateChangedSignal>(OnGameStateChanged);
    }

    private void HideTasks()
    {
        foreach (var item in _matchText.Values)
        {
            Destroy(item.gameObject);
        }

        _matchText.Clear();
    }

    private void OnTerminalClosed(TerminalPickedAndClosedSignal signal)
    {
        var items = ServiceLocator.Instance.Get<PickedItems>().Items;

        foreach (ItemData item in items)
        {
            _matchText[item] = Instantiate(_textPrefab.gameObject, _group.transform).GetComponent<TMP_Text>();
            _matchText[item].text = $"Найти предмет <color=red>\"{item.Name}\"</color>!";
        }
    }

    private void OnGetItem(GetItemInSceneSignal signal)
    {
        _matchText[signal.data].text = $"<s>{_matchText[signal.data].text}</s>";

        if (ServiceLocator.Instance.Get<PickedItems>().PlayerPickedItems.Count == ServiceLocator.Instance.Get<PickedItems>().Items.Count)
        {
            HideTasks();
        }
    }

    private void OnGameStateChanged(GameStateChangedSignal signal)
    {
        if (signal.state == GameState.GetAll)
        {
            HideTasks();
        }
    }
}
