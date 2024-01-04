using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Eventbus : MonoBehaviour
{
    //전역 변수로
    private static readonly Dictionary<string, UnityEvent> events = new Dictionary<string, UnityEvent>();
    public static void GetEvent(string code,UnityAction e)
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
    public static void RemoveEvent(string code, UnityAction e)
    {
        UnityEvent eve;
        if (events.TryGetValue(code, out eve))
        {
            eve.RemoveListener(e);
        }
    }
    public static void EventInvoke(string code)
    {
        UnityEvent eve;
        if (events.TryGetValue(code, out eve))eve?.Invoke();
    }
}
