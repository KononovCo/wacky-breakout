using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D physics;
    private EventManager events;

    [SerializeField]
    private int velocity = 4;

    [SerializeField]
    private int lifetime = 10;

    private void Awake()
    {
        events = GameManager.Instance.Events;
    }

    private void OnEnable()
    {
        events.Subscribe<BallAcceleratedEvent>(OnBallAccelerated);
        events.Subscribe<BallFrozenEvent>(OnBallFrozen);
    }

    private void OnDisable()
    {
        events.Unsubscribe<BallAcceleratedEvent>(OnBallAccelerated);
        events.Unsubscribe<BallFrozenEvent>(OnBallFrozen);
    }

    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();

        Vector2 direction = new(Random.Range(-1f, 1f), 1);
        Vector2 force = velocity * direction;

        events.Publish(new BallAddedEvent());

        GameManager.Instance.Delays.Run(1, () =>
        {
            physics.AddForce(force, ForceMode2D.Impulse);
            Destroy(gameObject, lifetime);
        });
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        events.Publish(new BallRemovedEvent());
    }

    private void OnBallAccelerated(BallAcceleratedEvent e)
    {
        if (e.Id == GetInstanceID())
        {
            physics.velocity *= 2;
        }
    }

    private void OnBallFrozen(BallFrozenEvent e)
    {
        if (e.Id == GetInstanceID())
        {
            physics.isKinematic = true;
            physics.velocity = Vector2.zero;

            GetComponent<SpriteRenderer>().color = e.Color;
        }
    }
}