using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance => GameManager.Instance.EventManager;

    private Dictionary<EventID, Action<object>> _events;

    private void Awake() 
    {
        _events = new Dictionary<EventID, Action<object>>();
    }

    public void Register(EventID eventType, Action<object> action)
    {
        Action<object> thisAction;
        if (_events.TryGetValue(eventType, out thisAction))
        {
            thisAction += action;
            _events[eventType] = thisAction;
        }
        else
        {
            thisAction += action;
            _events.Add(eventType, thisAction);
        }
    }

    public void Unregister(EventID eventType, Action<object> action)
    {
        Action<object> thisAction;
        if (_events.TryGetValue(eventType, out thisAction))
        {
            thisAction -= action;
            _events[eventType] = thisAction;
        }
    }

    public void Invoke(EventID eventType, object message)
    {
        Action<object> thisAction;
        if (_events.TryGetValue(eventType, out thisAction))
        {
            thisAction.Invoke(message);
        }
    }

    public void Invoke(EventID eventType)
    {
        Invoke(eventType, null);
    }
}
