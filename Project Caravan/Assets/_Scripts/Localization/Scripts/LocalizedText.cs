using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Sirenix.OdinInspector;
using System;

public class LocalizedText : SerializedMonoBehaviour
{
    public static LocalizedText instance;
    public LocalizationManager localizationManager;
    TextMeshProUGUI text;
    public GameObject background;

    [ReadOnly] public string currentCharacter = "";
    [ReadOnly] public Queue<string> queuedDialogues = new Queue<string>();
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
        text = GetComponent<TextMeshProUGUI>();
        text.text = "";
    }

    private void Update()
    {
        if(queuedDialogues.Count > 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                DisplayNextSentence();
            }
        }
    }
    public void InitDialogue(Dictionary<string,string> _dialogues, string _characterName)
    {
        queuedDialogues.Clear();
        currentCharacter = _characterName;
        background.SetActive(true);
        foreach (var key in _dialogues.Keys)
        {
            queuedDialogues.Enqueue(_dialogues[key]);
        }
        DisplayNextSentence();
    }

    [ContextMenu("Next sentence")]
    private void DisplayNextSentence()
    {
        if(queuedDialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = queuedDialogues.Dequeue();
        text.text =  sentence;
    }

    private void EndDialogue()
    {
        background.SetActive(false);
        text.text = "";
    }

    public void ShowDialogue(string _text)
    {
        text.text = _text;
   
    }
}
