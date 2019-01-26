using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;
using Sirenix.OdinInspector;

public class InteractableObject : MonoBehaviour
{
    #region Variables

    public enum InteractableTypes
    {
        SIMPLE_INTERACTABLE = 0,
        TOGGLE_INTERACTABLE = 1,
    }

    [Space]
    [EnumToggleButtons]
    public InteractableTypes interactableType;
    [Space]

   
    #endregion

    #region Interactable_Types

    [ShowIf("interactableType", InteractableTypes.SIMPLE_INTERACTABLE)]
    [SerializeField] SimpleInteractable simpleInteractable;

    [ShowIf("interactableType", InteractableTypes.TOGGLE_INTERACTABLE)]
    [SerializeField] ToggleInteractable toggleInteractable;

    #endregion

    private void Awake()
    {
        this.gameObject.layer = GlobalVariables.INTERACTABLE_LAYER;
    }

    public IInteractable GetInteractable()
    {
        switch(interactableType){
            case InteractableTypes.SIMPLE_INTERACTABLE:
                return simpleInteractable;
            case InteractableTypes.TOGGLE_INTERACTABLE:
                return toggleInteractable;
            default:
                return null;
        }
    }

    #region GIZMOS
    private void OnDrawGizmosSelected()
  {
        Gizmos.color = Color.blue;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        
  }


    private void OnDrawGizmos()
    {
        Vector3 offsetPosition = this.transform.position + Vector3.up * 3f;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, offsetPosition);
        Gizmos.DrawIcon(offsetPosition, "interactable_editor_icon.png", true);
    }


    #endregion

}
