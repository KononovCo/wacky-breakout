using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private readonly Dictionary<Type, Delegate> subscribers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        Type type = typeof(T);

        if (subscribers.TryGetValue(type, out Delegate value))
        {
            subscribers[type] = Delegate.Combine(value, handler);
        }

        else subscribers[type] = handler;
    }

    public void Unsubscribe<T>(Action<T> handler)
    {
        Type type = typeof(T);

        if (subscribers.TryGetValue(type, out Delegate value))
        {
            Delegate removed = Delegate.Remove(value, handler);

            if (removed == null) subscribers.Remove(type);
            else subscribers[type] = removed;
        }
    }

    public void Publish<T>(T eventType)
    {
        Type type = typeof(T);

        if (subscribers.TryGetValue(type, out Delegate value))
        {
            if (value is Action<T> handler)
            {
                handler.Invoke(eventType);
            }
        }
    }
}