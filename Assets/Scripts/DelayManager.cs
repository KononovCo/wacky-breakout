using System;
using System.Collections;
using UnityEngine;

public class DelayManager : MonoBehaviour
{
    private float delay;
    private Action action;

    private IEnumerator Run()
    {
        yield return new WaitForSecondsRealtime(delay);

        action();
        action = null;
    }

    public void Run(float delay, Action action)
    {
        this.delay = delay;
        this.action = action;

        StartCoroutine(Run());
    }
}