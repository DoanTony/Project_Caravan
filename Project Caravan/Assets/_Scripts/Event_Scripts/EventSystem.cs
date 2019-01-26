using UnityEngine;
using UnityEngine.Events;

public class EventSystem : MonoBehaviour
{
    [Header("Next event (GamebOject)")]
    public GameObject nextEvent;
    [Header("Events")]
    public UnityEvent _event;

    void Start()
    {
        InitializeEvent();
    }

     private void InitializeEvent()
    {
        ToggleNextEvent(false);
    }

    private void ToggleNextEvent(bool _state)
    {
        if (nextEvent)
        {
            nextEvent.SetActive(_state);
        }
    }

    public void InvokeEvent()
    {
        _event.Invoke();
        ToggleNextEvent(true);
    }
    
}
