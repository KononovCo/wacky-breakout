using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private EventManager events;
    private SoundManager sounds;
    private DelayManager delays;

    public static GameManager Instance
    {
        get => instance;
    }

    public EventManager Events
    {
        get => events;
    }

    public SoundManager Sounds
    {
        get => sounds;
    }

    public DelayManager Delays
    {
        get => delays;
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;

            events = GetComponent<EventManager>();
            sounds = GetComponent<SoundManager>();
            delays = GetComponent<DelayManager>();

            DontDestroyOnLoad(gameObject);
        }

        else Destroy(gameObject);
    }
}