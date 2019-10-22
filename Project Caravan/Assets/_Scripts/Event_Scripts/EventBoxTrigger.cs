using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class EventBoxTrigger : MonoBehaviour
{
    public enum TriggerTypes {
        ON_TRIGGER_ENTER,
        ON_TRIGGER_STAY,
        ON_TRIGGER_EXIT }

    public TriggerTypes triggerType;

    public UnityEvent Response;

    private void InvokeEvent()
    {
        Response.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerType == TriggerTypes.ON_TRIGGER_ENTER)
        {
            if (other.CompareTag("Portal"))
            {
                InvokeEvent();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (triggerType == TriggerTypes.ON_TRIGGER_STAY)
        {
            if (other.CompareTag("Portal"))
            {
                    if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space))
                {
                    InvokeEvent();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerType == TriggerTypes.ON_TRIGGER_EXIT)
        {
            if (other.CompareTag("Portal"))
            {
                InvokeEvent();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

    }

}
