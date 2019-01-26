using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueBox : MonoBehaviour
{

    #region Private variables
    [SerializeField] private string[] keys = new string[0];
    [SerializeField] private List<string> selectedKeys = new List<string>();
    [SerializeField] private int numDialogue;
    [SerializeField] private int[] enumIndex;
    private string LOCALIZATION_MANAGER_STRING = "LocalizationManager";

    #endregion

    #region Public Variables
    public string fileName;
    private LocalizationManager lm;
    #endregion

    #region Functions()

    public void FetchKeys()
    {
        if (lm == null)
        {
            lm = Resources.Load<LocalizationManager>(GlobalVariables.LOCALIZATION_PATH + LOCALIZATION_MANAGER_STRING);

        }
        lm.LoadEditorKeys(fileName);
        lm.LoadLocalizedText(fileName);
        keys = lm.GetKeys();
    }

    public void ClearLists()
    {
        selectedKeys.Clear();
    }

    public void CallDialiogue(int _index)
    {
        LocalizedText.instance.SetDialogue(selectedKeys[_index - 1], fileName);
    }


    #endregion

    #region Getters

    public int GetKeyLength()
    {
        return keys.Length;
    }

    public int GetDialogueLength()
    {
        return numDialogue;
    }

    public int[] GetEnumIndexes()
    {
        return enumIndex;
    }

    public string GetKeyIndexValue(int _index)
    {
        return keys[_index];
    }

    public string[] GetKeys()
    {
        return keys;
    }

    #endregion

    #region Setters
    public void SetKeys(string[] _keys)
    {
        selectedKeys.Clear();
        selectedKeys.AddRange(_keys);
    }

    public void SetDialogueLength(int _value)
    {
        numDialogue = _value;
        enumIndex = new int[numDialogue];
    }

    public void SetAvailableKey(string _key)
    {
        selectedKeys.Add(_key);
    }

    #endregion

}
