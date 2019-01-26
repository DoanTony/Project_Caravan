using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventBox : MonoBehaviour
{
    public enum EventTypes { ON_TRIGGER_ENTER, INTERACT, DROP_ITEM_AREA }
    public EventTypes eventType;

    public string tagName;
    public GameEvent gameEvent;
    //public string collisionTag;

    #region DROP ITEM PROPS
    [Tooltip("Specific item to be drop in the area")]
    [SerializeField] private InspectableItem dropLocation;
    [Tooltip("Don't destroy item on drop")]
    [SerializeField] private bool dontDestroyItem;
    #endregion

    #region NEXT EVENT PROPS
    public bool addNextEvent;
    public EventBox nextEvent;
    #endregion


    private void Awake()
    {
        switch (eventType)
        {
            case EventTypes.ON_TRIGGER_ENTER:
                this.transform.GetComponent<MeshRenderer>().enabled = false;
                break;
            case EventTypes.DROP_ITEM_AREA:
                this.gameObject.layer = GlobalVariables.DROP_AREA_LAYER;
                break;
        }
    }

    private void Start()
    {

    }

    public void DropArea(Item _item)
    {
        gameEvent.Raise();
        dropLocation.SetItem(_item);
        runtimeSet.activeCharacter.characterData.inventory.RemoveItem(_item);
    }


    private void StartNextEvent()
    {
        if (nextEvent)
        {
            nextEvent.PlayEvent();
        }
    }

    public void Interact()
    {
        PlayEvent();
    }

    public void PlayEvent()
    {
        gameEvent.Raise();
        //StartNextEvent();
        StartCoroutine("DelayDestroy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName)
        {
            switch (eventType)
            {
                case EventTypes.ON_TRIGGER_ENTER:
                    PlayEvent();
                    break;
            }
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
