using UnityEngine;
using System.Collections;

public class InteractionComponent : Interaction
{
    public int flipX = 1;

    public Vector3 forward;

    private void Update()
    {
        forward = Vector3.right * flipX;
    }

    public override void Interact(IInteractable _interactable)
    {
        _interactable.Interact();
    }

    public override void OnDrawGizmosSelected()
    {
        if (showRaycast)
        {
            Debug.DrawRay(transform.position, transform.right.normalized * flipX * range, Color.blue);
        }
    }
}
