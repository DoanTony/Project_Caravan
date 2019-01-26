using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Controls/Inputs/Once", order = 0)]
public class OnceInput : InteractionInput
{
    public string keycodeName;
    
    public override void Interact(Interactable _interactable)
    {
        if (Input.GetButtonDown(keycodeName))
        {
            _interactable.Execute();
        }
    }
}