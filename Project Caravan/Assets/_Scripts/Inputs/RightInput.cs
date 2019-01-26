using UnityEngine;

[CreateAssetMenu(menuName = "Controls/Inputs/Right Input", order = 0)]
public class RightInput : InteractionInput
{
    public override void Interact(Interactable _interactable)
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        if (horizontal > 0)
        {
            _interactable.Execute();
        }
    }
}