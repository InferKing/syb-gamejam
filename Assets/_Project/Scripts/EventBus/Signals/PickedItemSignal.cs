using Model.Items;

public class PickedItemSignal
{
    public readonly ItemData data;
    public PickedItemSignal(ItemData data)
    {
        this.data = data;
    }
}
