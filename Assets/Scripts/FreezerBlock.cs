using UnityEngine;

public class FreezerBlock : Block
{
    protected override void OnEffect(int id)
    {
        EventManager events = GameManager.Instance.Events;
        Color color = GetComponent<SpriteRenderer>().color;

        events.Publish(new BallFrozenEvent(id, color));
    }
}