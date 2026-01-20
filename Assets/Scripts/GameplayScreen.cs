using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class GameplayScreen : MonoBehaviour
{
    private EventManager events;

    private int ballCount = 0;
    private int pointCount = 0;

    [SerializeField]
    private TextMeshProUGUI balls;

    [SerializeField]
    private TextMeshProUGUI points;

    [SerializeField]
    private GameObject gameOverMenu;

    private void Awake()
    {
        events = GameManager.Instance.Events;
    }

    private void OnEnable()
    {
        events.Subscribe<BallAddedEvent>(OnBallAdded);
        events.Subscribe<BallRemovedEvent>(OnBallRemoved);
        events.Subscribe<PointsAddedEvent>(OnPointsAdded);
    }

    private void OnDisable()
    {
        events.Unsubscribe<BallAddedEvent>(OnBallAdded);
        events.Unsubscribe<BallRemovedEvent>(OnBallRemoved);
        events.Unsubscribe<PointsAddedEvent>(OnPointsAdded);
    }

    private int ReadValue(TextMeshProUGUI text)
    {
        Regex regex = new(@"\d+");
        Match match = regex.Match(text.text);

        return int.Parse(match.Value);
    }

    private void UpdateValue(TextMeshProUGUI text, int value)
    {
        string target = ReadValue(text).ToString();
        string replacement = value.ToString();

        text.text = text.text.Replace(target, replacement);
    }

    private void OnBallAdded(BallAddedEvent e)
    {
        ballCount++;
        UpdateValue(balls, ballCount);
    }

    private void OnBallRemoved(BallRemovedEvent e)
    {
        ballCount--;
        UpdateValue(balls, ballCount);

        gameOverMenu.SetActive(ballCount == 0);
    }

    private void OnPointsAdded(PointsAddedEvent e)
    {
        pointCount += e.Amount;
        UpdateValue(points, pointCount);
    }
}