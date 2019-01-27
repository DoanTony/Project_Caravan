using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    public void LoadScene(string _sceneName)
    {
        for (int i = 0; i < 4; i++)
        {
            string outdoorString = "Outdoor" + (i+1);
            if (outdoorString == _sceneName)
            {
                if (!SceneManager.GetSceneByName(outdoorString).isLoaded)
                {
                    SceneManager.LoadSceneAsync(outdoorString, LoadSceneMode.Additive);
                }
            }
            else
            {
                if (SceneManager.GetSceneByName(outdoorString).isLoaded)
                {
                    SceneManager.UnloadSceneAsync(outdoorString);
                }
            }
        }
    }


}
