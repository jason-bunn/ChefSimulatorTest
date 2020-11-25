using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager 
{
    
    private static Dictionary<string, List<IActor>> m_events;

    public static void Initialize()
    {
        m_events = new Dictionary<string, List<IActor>>();
        m_events["Player_1_Action"] = new List<IActor>();
        m_events["Player_2_Action"] = new List<IActor>();
    }

    public static void Subscribe(string eventName, IActor actor)
    {
        if(!m_events.ContainsKey(eventName))
        {
            List<IActor> newList = new List<IActor>();
            newList.Add(actor);
            m_events.Add(eventName, newList);
        }
        else
        {
            m_events[eventName].Add(actor);
        }
    }

    public static void Unsubscribe(string eventName, IActor actor)
    {
        if(!m_events.ContainsKey(eventName))
        {
            Debug.Log("Cannot unsubscribe from an unknown event");
            return;
        }

        m_events[eventName].Remove(actor);
    }

    public static void DispatchEvent(string eventName, IActor emitter)
    {
        if (!m_events.ContainsKey(eventName))
        {
            Debug.Log("Cannot dispatch an unknown event");
            return;
        }
        for(int i = 0; i < m_events[eventName].Count; i++)
        {
            m_events[eventName][i].ReceiveAction(emitter);
        }
    }
}
