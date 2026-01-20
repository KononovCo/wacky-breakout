using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Dictionary<SoundType, AudioClip> sources;

    [SerializeField]
    private Sound[] sounds;

    private void Start()
    {
        sources = new();

        foreach (Sound sound in sounds)
        {
            sources.Add(sound.Key, sound.Value);
        }
    }

    public void Play(SoundType type)
    {
        if (sources.ContainsKey(type))
        {
            AudioClip sound = sources[type];
            GameObject temp = new(sound.name);
            AudioSource source = temp.AddComponent<AudioSource>();

            source.PlayOneShot(sound);
            Destroy(temp, sound.length);
        }
    }
}