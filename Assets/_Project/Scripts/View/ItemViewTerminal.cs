using Model.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemViewTerminal : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Image _completed;
    [SerializeField]
    private Image _selected;
    [SerializeField]
    private TMP_Text _text;

    private ItemData _data;
    public ItemData Data => _data;

    public bool IsCompleted { get; private set; }
    public bool IsSelected { get; private set; }

    public void SetView(ItemData data)
    {
        _data = data;
        UpdateView();
    }

    public void UpdateView()
    {
        _icon.sprite = _data.Sprite;
        _text.text = _data.Name;
        _selected.color = IsSelected && !IsCompleted ? Color.yellow : Color.white;
        _completed.enabled = IsCompleted;
    }

    public void ResetToDefault()
    {
        IsSelected = false;
        IsCompleted = false;

        _icon.sprite = _data.Sprite;
        _text.text = _data.Name;
        _selected.color = IsSelected && !IsCompleted ? Color.yellow : Color.white;
        _completed.enabled = IsCompleted;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsCompleted)
        {
            return;
        }

        PickedItems picked = ServiceLocator.Instance.Get<PickedItems>();

        if (picked.Items.Count >= ServiceLocator.Instance.Get<GameModel>().CurrentTask.task.Items.Count)
        {
            if (IsSelected && picked.Items.Contains(_data))
            {
                IsSelected = !IsSelected;
                ServiceLocator.Instance.Get<EventBus>().Invoke(new UnpickedItemSignal(_data));
            }
        }
        else
        {
            IsSelected = !IsSelected;
            ServiceLocator.Instance.Get<EventBus>().Invoke(new PickedItemSignal(_data));
        }
        UpdateView();
    }
}
