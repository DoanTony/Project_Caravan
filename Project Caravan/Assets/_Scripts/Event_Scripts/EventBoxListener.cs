using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using SnowtailTools.Utilities;

[ExecuteAlways]
public class EventBoxListener : MonoBehaviour
{

    public GameEvent gameEvent;
    public UnityEvent Response;

    private void OnEnable()
    {
        AddListener();
    }

    private void OnDisable()
    {
        RemoveListener();
    }

    [ContextMenu("Debug visual")]
    private void AddListener()
    {
#if UNITY_EDITOR
        if (!Validation.ValidateField<GameEvent>(gameEvent, this.name + " is missing a game Event!", this.gameObject)) // Validate and log if missing gameEvent
            return;
#endif
        gameEvent.RegisterListener(this);
    }

    private void RemoveListener()
    {
#if UNITY_EDITOR
        if (!Validation.ValidateField<GameEvent>(gameEvent, this.name + " is missing a game Event!", this.gameObject)) // Validate and log if missing gameEvent
            return;
#endif
        gameEvent.UnregisterListener(this);
    }

    public virtual void OnRaisedEvent()
    {
        Response.Invoke();
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        if (Validation.ValidateField<GameEvent>(gameEvent, this.name + " is missing a game Event!", this.gameObject)) // Validate and log if missing gameEvent
            gameEvent.RegisterListener(this);
#endif

        //Indicator
        Vector3 offsetPosition = this.transform.position + Vector3.up * 3f;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, offsetPosition);
        Gizmos.DrawIcon(offsetPosition, "event_listener_editor_icon.png", true);

        //Label
        GUIStyle _myStyle = new GUIStyle();
        _myStyle.normal.textColor = Color.yellow;
        _myStyle.fontStyle = FontStyle.Bold;
        _myStyle.fontSize = 14;
        Handles.Label(this.transform.position + Vector3.up * 5f, this.name, _myStyle);

    }
}
