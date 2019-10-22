using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class ToggleInteractable : Interactable
{
    [Header("Delay toggle (In seconds)")]
    [Range(1, 5)]
    public float delayToggle = 1;

    [Header("On Active On")]
    public UnityEvent onResponse;

    [Header("On Active Off ")]
    public UnityEvent offResponse;


    [HideInInspector] public bool isActive = false;
    private bool canToggleAgain;

    public void Start()
    {
        canToggleAgain = true;
    }

    public override void Execute()
    {
        if (isActive)
        {
            isActive = false;
            offResponse.Invoke();

            if (canToggleAgain)
            {
               // canToggleAgain = false;
               // StartCoroutine(DelayToggle());
            }
        }
        else
        {
            isActive = true;
            onResponse.Invoke();
            if (canToggleAgain)
            {
                //canToggleAgain = false;
              //StartCoroutine(DelayToggle());
            }
        }
    }

    private IEnumerator DelayToggle()
    {
        yield return new WaitForSeconds(delayToggle);
        canToggleAgain = true;
    }

}
