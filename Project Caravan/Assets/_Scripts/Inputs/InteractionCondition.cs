using UnityEngine;
using System.Collections.Generic;

public abstract class InteractionInput : ScriptableObject
{
    public abstract void Interact(Interactable _interactable);
}