using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Localization Collection", menuName = "Localization/Collection", order = 2)]
public class LocalizationBox : SerializedScriptableObject
{
    #region Public Variables
    public string fileName;
    private LocalizationManager lm;
    #endregion
    [Space]

    #region Private variables
    [SerializeField] private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    [Space]
    private string LOCALIZATION_MANAGER_STRING = "LocalizationManager";
    #endregion

    #region Functions()
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
    }

    public void ClearLists()
    {
        localizedText.Clear();
    }

    public void CallDialiogue(int _index)
    {
        //LocalizedText.instance.SetDialogue(selectedKeys[_index - 1], fileName);
    }

    public void ShowDialogue(string _key)
    {
        LocalizedText.instance.ShowDialogue(localizedText[_key]);
    }

    #endregion

    #region Getters

    public int GetKeyLength()
    {
        return localizedText.Count;
    }

    #endregion
}