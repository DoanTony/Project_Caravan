using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using SnowtailTools.Utilities;
using System.Linq;

[CreateAssetMenu(fileName = "Localization Collection", menuName = "Localization/Collection", order = 2)]
public class LocalizationBox : SerializedScriptableObject
{
    #region Public Variables
    public string fileName;
    private LocalizationManager lm;
    #endregion
    [Space]

    #region Private variables
    [SerializeField] [ReadOnly] private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    [Space]
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
    [Title("Functionalities")]
    [Button(ButtonSizes.Gigantic , ButtonStyle.CompactBox)]
    public void FetchLocalizedText()
    {
        if (lm == null)
        {
            lm = Resources.Load<LocalizationManager>(GlobalVariables.LOCALIZATION_PATH + LOCALIZATION_MANAGER_STRING);

        }
        lm.LoadEditorKeys(fileName);
        lm.LoadLocalizedText(fileName);
        localizedText = lm.GetLocalizedTexts();
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
            LocalizedText.instance.ShowDialogue(localizedText[_key]);
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