using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EventTimer : MonoBehaviour
{
    [FormerlySerializedAs("Timer (S)")]
    public float timer;
    public UnityEvent response;

    public void StartTimer()
    {
        StartCoroutine(EventStart());
    }

    private IEnumerator EventStart()
    {
        yield return new WaitForSeconds(timer);
        response.Invoke();
    }
}
