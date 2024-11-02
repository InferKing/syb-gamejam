using Model.Items;

public class PlayerGetItemSignal
{
    public readonly ItemData data;
    public PlayerGetItemSignal(ItemData data)
    {
        this.data = data;
    }
}
