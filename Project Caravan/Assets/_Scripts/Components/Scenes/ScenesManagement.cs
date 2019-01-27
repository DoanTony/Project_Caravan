using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
   public enum OutdoorScenes
    {
        Outdoor_1,
        Outdoor_2,
        Outdoor_3,
        Outdoor_4
    }

    public OutdoorScenes currentOutdoorScene;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetScene(OutdoorScenes.Outdoor_1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetScene(OutdoorScenes.Outdoor_2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetScene(OutdoorScenes.Outdoor_3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetScene(OutdoorScenes.Outdoor_4);
        }
    }

    public void SetScene(OutdoorScenes _scene)
    {
        switch (_scene)
        {
            case OutdoorScenes.Outdoor_1:
                LoadScene("Outdoor1");
                break;
            case OutdoorScenes.Outdoor_2:
                LoadScene("Outdoor2");
                break;
            case OutdoorScenes.Outdoor_3:
                LoadScene("Outdoor3");
                break;
            case OutdoorScenes.Outdoor_4:
                LoadScene("Outdoor4");
                break;
        }
    }

    private void LoadScene(string _sceneName)
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
