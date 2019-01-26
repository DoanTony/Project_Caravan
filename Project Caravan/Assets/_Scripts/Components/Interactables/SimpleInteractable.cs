using UnityEngine.Events;

[System.Serializable]
public class SimpleInteractable : Interactable
{
    public UnityEvent response;

    public override void Execute()
    {
        response.Invoke();
    }

   
}
