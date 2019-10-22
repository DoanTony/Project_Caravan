using UnityEngine;
using Unity.Entities;
using SnowtailTools;

public class InteractionSystem : ComponentSystem
{
    struct Characters
    {
        public readonly int Length;
        public ComponentArray<InteractionComponent> Interaction;
        public ComponentArray<Character> Character;
        public ComponentArray<Transform> Transform;
    }

    [Inject] Characters _Characters;

    protected override void OnUpdate()
    {
        for (int i = 0; i < _Characters.Length; i++)
        {
            ScanForInteractable(i);

            if (_Characters.Interaction[i].interactable != null)
            {
                _Characters.Interaction[i].interactable.Interact();
            }
        }
    }

    private void ScanForInteractable(int index)
    {
        LayerMask layerMask = 1 << GlobalVariables.INTERACTABLE_LAYER;
        RaycastHit hit;
        Ray ray = new Ray(_Characters.Transform[index].position + (_Characters.Interaction[index].forward.normalized * -1.5f), _Characters.Interaction[index].forward);
        if (Physics.Raycast(ray, out hit, _Characters.Interaction[index].range, layerMask))
        {
            _Characters.Interaction[index].interactable = hit.transform.GetComponent<InteractableObject>().GetInteractable();
            _Characters.Interaction[index].interactableInRange = true;
        }
        else
        {
            _Characters.Interaction[index].interactable = null;
            _Characters.Interaction[index].interactableInRange = false;
        }

    }
}
