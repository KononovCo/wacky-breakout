public readonly struct BallAcceleratedEvent
{
    private readonly int id;

    public int Id
    {
        get => id;
    }

    public BallAcceleratedEvent(int id)
    {
        this.id = id;
    }
}