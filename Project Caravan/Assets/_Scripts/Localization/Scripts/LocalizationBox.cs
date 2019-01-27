using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using SnowtailTools.Utilities;
using System.Linq;

public struct AnswerQuestionDialogue
{
    public string answer;
    public LocalizationBox nextQueueDialogue;
}

[CreateAssetMenu(fileName = "Localization Collection", menuName = "Localization/Collection", order = 2)]
public class LocalizationBox : SerializedScriptableObject
{
    #region Public Variables
    [HideInInspector] public string fileName; // Disabling this for Game Jam
    [Title("Character information")]
    public string characterName = "name";

    [Title("List of Dialogues")]
    public readonly SortedDictionary<string, string> localizedText = new SortedDictionary<string, string>();
    [Space]

    //Next dialogue (optional)
    [Title("Next Queue Dialogue")]

    [DisableIf("isAnswers")]
    public bool isNextQueue;
    [ShowIf("isNextQueue")]
    public LocalizationBox nextQueue;

    [DisableIf("isNextQueue")]
    public bool isAnswers;
    [ShowIf("isAnswers")]
    public AnswerQuestionDialogue[] answerQuestions = new AnswerQuestionDialogue[3];

    [Title("Events")]
    public bool isEvent;
    [ShowIf("isEvent")]
    public GameEvent endDialogueEvent;

 
    #endregion
    [Space]

    #region Private variables
    private LocalizationManager lm;
    private string LOCALIZATION_MANAGER_STRING = "LocalizationManager";
    #endregion

#if UNITY_EDITOR

    #region DEBUGGER
    [Title("Debug")]
    [ValueDropdown("keys")] public string key;
    private string[] keys;
    [Button("Debug Dialogue (Console)", ButtonSizes.Large)]
    public void DebugShowDialog()
    {
        if (!Validation.ValidateField<string>(key, "Please select a key"))
            return;

        Debug.Log(localizedText[key]);
    }

    [Button("Debug Dialogue (Play Mode)", ButtonSizes.Large)]
    public void DebugShowDialogPlayMode()
    {
        if (!Validation.ValidateField<string>(key, "Please select a key"))
            return;

        ShowDialogue(key);
    }

    #endregion

    #region FUNCTIONALITIES
    public void FetchLocalizedText()
    {
        if (lm == null)
        {
            lm = Resources.Load<LocalizationManager>(GlobalVariables.LOCALIZATION_PATH + LOCALIZATION_MANAGER_STRING);

        }
        lm.LoadEditorKeys(fileName);
        lm.LoadLocalizedText(fileName);
        //localizedText = lm.GetLocalizedTexts();
        keys = localizedText.Keys.ToArray();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.CompactBox)]
    public void ClearLists()
    {
        localizedText.Clear();
        keys = null;
    }

    public void ShowDialogue(string _key)
    {
        if (Validation.ValidateField<LocalizedText>(LocalizedText.instance, "Please add an instance of localized text and be on <i>PLAY MODE</i>"))
        {
            LocalizedText.instance.ShowDialogue(characterName + ": " + localizedText[_key]);
            //LocalizedText.instance.InitDialogue(localizedText, characterName);
        }
    }

    public void InitDialogue()
    {
        if (Validation.ValidateField<LocalizedText>(LocalizedText.instance, "Please add an instance of localized text and be on <i>PLAY MODE</i>"))
        {
            LocalizedText.instance.InitDialogue(this);
        }
    }
    #endregion

#endif

    #region Getters

    public int GetKeyLength()
    {
        return localizedText.Count;
    }

    #endregion
}