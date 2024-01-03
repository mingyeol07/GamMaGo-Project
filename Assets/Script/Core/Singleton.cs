using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    protected static T _ins;
    public static T ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = FindObjectOfType<T>();
                if (_ins == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _ins = obj.AddComponent<T>();
                }
            }
            return _ins;
        }
    }
    protected virtual void Awake()
    {
        if (_ins == null)
        {
            _ins = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
