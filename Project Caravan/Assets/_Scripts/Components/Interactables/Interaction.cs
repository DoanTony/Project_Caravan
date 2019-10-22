using UnityEngine;
using Unity.Entities;

[RequireComponent(typeof(GameObjectEntity))]
[SerializeField]
public abstract class Interaction : MonoBehaviour
{
    public float range;
    public bool showRaycast;
    [HideInInspector] public bool isInteracting;
    public bool interactableInRange;
    public IInteractable interactable;

    public abstract void Interact(IInteractable _interactable);

    public virtual void OnDrawGizmosSelected() { }
}
