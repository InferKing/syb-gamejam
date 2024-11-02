using Model.Items;

public class UnpickedItemSignal
{
    public readonly ItemData data;
    public UnpickedItemSignal(ItemData data)
    {
        this.data = data;
    }
}
