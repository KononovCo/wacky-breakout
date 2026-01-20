public readonly struct PointsAddedEvent
{
    private readonly int amount;

    public int Amount
    {
        get => amount;
    }

    public PointsAddedEvent(int amount)
    {
        this.amount = amount;
    }
}