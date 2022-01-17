using UnityEngine;
using Unity.Entities;
using SnowtailTools;

public class InteractionSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Character entity, InteractionComponent interaction, Transform transform) =>
        {
            ScanForInteractable(interaction, transform);

            if (interaction.interactable != null && entity.GetComponent<CharacterController>().IsActive && Input.GetKeyDown(KeyCode.Space))
            {
                interaction.interactable.Interact();
                interaction.interactable.Execute();

            }

        });
    }

    private void ScanForInteractable(InteractionComponent interaction, Transform transform)
    {
        LayerMask layerMask = 1 << GlobalVariables.INTERACTABLE_LAYER;
        RaycastHit hit;
        Ray ray = new Ray(transform.position + (interaction.forward.normalized * -1.5f), interaction.forward);
        Debug.DrawRay(transform.position, ray.direction * interaction.range, Color.green);
        if (Physics.Raycast(ray, out hit, interaction.range, layerMask))
        {
            interaction.interactable = hit.transform.GetComponent<InteractableObject>().GetInteractable();
            interaction.interactableInRange = true;
        }
        else
        {
            interaction.interactable = null;
            interaction.interactableInRange = false;
        }

    }
}
