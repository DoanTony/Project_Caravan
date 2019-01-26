using UnityEngine;
using System.Collections;

public class InteractionComponent : Interaction
{
    public override void Interact(IInteractable _interactable)
    {
        _interactable.Interact();
    }

    public override void OnDrawGizmosSelected()
    {
        if (showRaycast)
        {
            Debug.DrawRay(transform.position, transform.forward.normalized * range, Color.blue);
        }
    }
}
