using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent : ScriptableObject
{
    public List<EventBoxListener> listeners = new List<EventBoxListener>();

    // Raise events
    public abstract void Raise();

    /// Add listener to the list
    public void RegisterListener(EventBoxListener _listener)
    {
        if (!listeners.Contains(_listener))
        {
            listeners.Add(_listener);
        }
    }

    /// Remove listener from the list
    public void UnregisterListener(EventBoxListener _listener)
    {
        if (listeners.Contains(_listener))
        {
            listeners.Remove(_listener);
        }
    }


    public void OnDisable()
    {
        listeners.Clear();
    }
}
