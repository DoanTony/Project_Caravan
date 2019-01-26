using UnityEngine;

[CreateAssetMenu(menuName = "Events/Generic", order = 0)]
public class GenericEvent : GameEvent
{
    public override void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnRaisedEvent();
        }
    }
}