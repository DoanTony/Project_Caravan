using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : IInteractable
{
    // Function used to execute any action after input
    public abstract void Execute();

    public void Interact()
    {
    //    if (input)
    //    {
    //        input.Interact(this);
    //    }
    //    else
    //    {
    //        //Debug.LogError("Please add an input option to " + this.transform.name);
    //    }
    }
 
}
