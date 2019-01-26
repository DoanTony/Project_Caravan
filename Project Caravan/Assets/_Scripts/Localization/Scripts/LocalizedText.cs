using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalizedText : MonoBehaviour
{
    public static LocalizedText instance;
    public LocalizationManager localizationManager;
    Text text;
    private void Awake()
    {
        InitializeSingleton();
    }

    public void InitializeSingleton()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    public void SetDialogue(string key, string _filename)
    {
        text.text = localizationManager.GetLocalizedValue(key, _filename);
        StopCoroutine(DelayClearText());
        StartCoroutine(DelayClearText());
    }

    public void ShowDialogue(string _text)
    {
        text.text = _text;
        StopCoroutine(DelayClearText());
        StartCoroutine(DelayClearText());
    }

    private IEnumerator DelayClearText()
    {
        yield return new WaitForSeconds(4.0f);
        text.text = "";
    }
}
