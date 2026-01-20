using UnityEngine;

public readonly struct BallFrozenEvent
{
    private readonly int id;
    private readonly Color color;

    public int Id
    {
        get => id;
    }

    public Color Color
    {
        get => color;
    }

    public BallFrozenEvent(int id, Color color)
    {
        this.id = id;
        this.color = color;
    }
}