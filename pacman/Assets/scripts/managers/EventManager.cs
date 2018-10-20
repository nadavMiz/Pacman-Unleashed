using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    private void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void Subscribe(string _eventName, UnityAction _listener)
    {
        if (instance == null) return;

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(_eventName, out thisEvent))
        {
            thisEvent.AddListener(_listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(_listener);
            instance.eventDictionary.Add(_eventName, thisEvent);
        }
    }

    public static void Unsubscribe(string _eventName, UnityAction _listener)
    {
        if (instance == null) return;

        UnityEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(_eventName, out thisEvent))
        {
            thisEvent.RemoveListener(_listener);
        }
    }

    public static void TriggerEvent(string _eventName)
    {
        if (instance == null)
        {
            return;
        }

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(_eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
