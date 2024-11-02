using System.Collections.Generic;
using System.Linq;
using Model.Items;

public class PickedItems : IService
{
    // выбранные в терминале
    private List<ItemData> _pickedItems = new();
    // подобранные игроком на сцене
    private List<ItemData> _playerPickedItems = new();
    private EventBus _bus;
    
    public PickedItems(EventBus bus)
    {
        _bus = bus;
        _bus.Subscribe<PickedItemSignal>(OnPickedItem);
        _bus.Subscribe<UnpickedItemSignal>(OnUnpickedItem);
        _bus.Subscribe<FailedTaskSignal>(OnFailedTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);
        _bus.Subscribe<GetItemInSceneSignal>(OnGetItem);
    }

    private void OnPickedItem(PickedItemSignal signal)
    {
        if (!_pickedItems.Contains(signal.data))
        {
            _pickedItems.Add(signal.data);
        }
    }

    private void OnUnpickedItem(UnpickedItemSignal signal)
    {
        if (_pickedItems.Contains(signal.data))
        {
            _pickedItems.Remove(signal.data);
        }
    }

    private void OnFailedTask(FailedTaskSignal signal)
    {
        _pickedItems.Clear();
    }

    private void OnSuccessTask(SuccessTaskSignal signal)
    {
        _pickedItems.Clear();
    }

    private void OnGetItem(GetItemInSceneSignal signal)
    {
        _playerPickedItems.Add(signal.data);
    }

    public List<ItemData> Items => _pickedItems.ToList();
    public List<ItemData> PlayerPickedItems => _playerPickedItems.ToList();
}
