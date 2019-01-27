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
    public float letterDelay = 0.5f;

    [Title("AnswerButtons")]
    public GameObject[] answerButtons = new GameObject[3];

    [ReadOnly] public string currentCharacter = "";
    [ReadOnly] public Queue<string> queuedDialogues = new Queue<string>();

    private bool canDequeueNextSentence = false;
    private LocalizationBox nextDialogue;
    private LocalizationBox currentDialogue;
    private AnswerQuestionDialogue[] answerQuestionDialogues;

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
        if (canDequeueNextSentence)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                DisplayNextSentence();
            }
        }
    }
    public void InitDialogue(LocalizationBox _dialoguebox)
    {
        queuedDialogues.Clear();
        currentCharacter = _dialoguebox.characterName;
        background.SetActive(true);
        nextDialogue = null;
        answerQuestionDialogues = null;
        currentDialogue = _dialoguebox;

        foreach (var key in _dialoguebox.localizedText.Keys)
        {
            queuedDialogues.Enqueue(_dialoguebox.localizedText[key]);
        }

        // Queue up next dialogue
        if (_dialoguebox.isNextQueue)
        {
            nextDialogue = _dialoguebox.nextQueue;
        }

        if (_dialoguebox.isAnswers)
        {
            answerQuestionDialogues = _dialoguebox.answerQuestions;
        }

        DisplayNextSentence();
    }

    [ContextMenu("Next sentence")]
    private void DisplayNextSentence()
    {
        ResetButtons();
        canDequeueNextSentence = false;

        if (queuedDialogues.Count == 0)
        {           
            if (nextDialogue != null)
            {
                if (currentDialogue.isEvent)
                {
                    currentDialogue.endDialogueEvent.Raise();
                }

                InitDialogue(nextDialogue);
                return;
            }          
            EndDialogue();
            return;
        }

        string sentence = queuedDialogues.Dequeue();
        StopCoroutine("TypeSentence");
        StartCoroutine(TypeSentence(sentence));
    }

    private void EndDialogue()
    {
        if (currentDialogue.isEvent)
        {
            currentDialogue.endDialogueEvent.Raise();
        }
        background.SetActive(false);
        text.text = "";
    }

    public void ShowDialogue(string _text)
    {
        text.text = _text;
    }

    private IEnumerator TypeSentence(string _sentence)
    {
        text.text = currentCharacter + ": \n ";
        foreach (Char letter in _sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
        if (queuedDialogues.Count == 0 && answerQuestionDialogues != null)
        {
            EnableButtons(answerQuestionDialogues);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            canDequeueNextSentence = true;
        }
      
    }

    public void AnswerQuestion(int _index)
    {
        InitDialogue(answerQuestionDialogues[_index].nextQueueDialogue);
    }

    private void EnableButtons(AnswerQuestionDialogue[] _answerQuestionDialogues)
    {
        for (int i = 0; i < _answerQuestionDialogues.Length; i++)
        {
            if (_answerQuestionDialogues[i].nextQueueDialogue != null)
            {
                answerButtons[i].SetActive(true);
                answerButtons[i].GetComponentInChildren<Text>().text = answerQuestionDialogues[i].answer;
            }
        }
    }
    
    private void ResetButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            answerButtons[i].SetActive(false);
        }
    }
}
