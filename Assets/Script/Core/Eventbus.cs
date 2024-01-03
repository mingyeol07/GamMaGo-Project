using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventbus : MonoBehaviour
{
    private static readonly Dictionary<int, UnityEvent> events = new Dictionary<int, UnityEvent>();
    public static void GetEvent(int code,UnityAction e)
    {
        UnityEvent eve;
        if(events.TryGetValue(code,out eve))
        {
            eve.AddListener(e);
        }
        else
        {
            eve = new UnityEvent();
            eve.AddListener(e);
            events.Add(code, eve);
        }
    }
    public static void RemoveEvent(int code, UnityAction e)
    {
        UnityEvent eve;
        if (events.TryGetValue(code, out eve))
        {
            eve.RemoveListener(e);
        }
    }
    public static void EventInvoke(int code)
    {
        UnityEvent eve;
        if (events.TryGetValue(code, out eve))eve?.Invoke();
    }
}
