using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

[CreateAssetMenu(fileName = "Localization Manager", menuName = "Manager/Localization")]
public class LocalizationManager : ScriptableObject
{
    #region Private variables
    private bool isReady;
    private string missingTextString = "< Localize text not found! > ";
    private SortedDictionary<string, string> localizedText;
    private string[] keys;
    #endregion

    #region LoadLocalizedText()

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new SortedDictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");
        if (File.Exists(filePath))
        {
            string dataAsJSon = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJSon);
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Data Loaded, dictionnary contain : " + localizedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
        isReady = true;
    }

    #endregion

    #region GetLocalizedValue()

    public string GetLocalizedValue(string _key, string _filename) 
    {
        string result = missingTextString;
        if (localizedText != null)
        {
            localizedText.Clear();
        }
        LoadLocalizedText(_filename);

        if (localizedText.ContainsKey(_key))
        {
            result = localizedText[_key];
        }
        else
        {
            result = "";
        }
        return result;
    }

    #endregion

    #region Getters

    public string[] GetKeys()
    {
        return keys;
    }

    public bool GetIsReady()
    {
        return isReady;
    }

    public SortedDictionary<string,string> GetLocalizedTexts()
    {
        return localizedText;
    }

    #endregion

    #region Load keys for local editor uses
    public void LoadEditorKeys(string fileName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");
        if (File.Exists(filePath))
        {
            string dataAsJSon = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJSon);
            string[] temp_keys = new string[loadedData.items.Length];
            for (int i = 0; i < loadedData.items.Length; i++)
            {
                temp_keys[i] = loadedData.items[i].key;
            }
            keys = temp_keys;
            Debug.Log("Data Loaded, dictionnary contain : " + temp_keys.Length + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file " + fileName + "!");
        }
    }
    #endregion
}
