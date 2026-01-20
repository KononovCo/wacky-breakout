using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField]
    private int points = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            EventManager events = GameManager.Instance.Events;
            events.Publish(new PointsAddedEvent(points));

            OnEffect(ball.GetInstanceID());
            Destroy(gameObject);
        }
    }

    protected abstract void OnEffect(int id);
}