public class AccelerationBlock : Block
{
    protected override void OnEffect(int id)
    {
        EventManager events = GameManager.Instance.Events;
        events.Publish(new BallAcceleratedEvent(id));
    }
}