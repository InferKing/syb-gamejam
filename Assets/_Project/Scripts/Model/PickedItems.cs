using System.Collections.Generic;
using Model.Items;

public class PickedItems
{
    private List<ItemData> _pickedItems = new();
    private EventBus _bus;
    
    public PickedItems(EventBus bus)
    {
        _bus = bus;
        _bus.Subscribe<PickedItemSignal>(OnPickedItem);
        _bus.Subscribe<UnpickedItemSignal>(OnUnpickedItem);
        _bus.Subscribe<FailedTaskSignal>(OnFailedTask);
        _bus.Subscribe<SuccessTaskSignal>(OnSuccessTask);
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
}
