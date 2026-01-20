using System;
using UnityEngine;

[Serializable]
public class Sound
{
    [SerializeField]
    private SoundType key;

    [SerializeField]
    private AudioClip value;

    public SoundType Key
    {
        get => key;
    }

    public AudioClip Value
    {
        get => value;
    }
}