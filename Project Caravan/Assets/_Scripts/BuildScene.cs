using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class BuildScene : MonoBehaviour
{

    public static BuildScene instance;
#if UNITY_EDITOR
    public SceneAsset mainScene;
    public List<SceneAsset> additiveScenes = new List<SceneAsset>();
#endif
    [SerializeField] private string buildMainScene;
    [SerializeField] private List<string> buildScenes = new List<string>();
    [SerializeField] private bool isMainSceneLoaded;

    private void Awake()
    {
        StartCoroutine(LoadYourAsyncScene(buildMainScene, LoadSceneMode.Single));
    }

    [ContextMenu("Add Scenes")]
    private void AddScenes()
    {
#if UNITY_EDITOR
        buildScenes.Clear();
        buildMainScene = mainScene.name;
        for (int i = 0; i < additiveScenes.Count; i++)
        {
            buildScenes.Add(additiveScenes[i].name);
        }

#endif
    }

    private void LoadAdditiveScenes()
    {
        for (int i = 0; i < buildScenes.Count; i++)
        {
            LoadYourAsyncScene(buildScenes[i], LoadSceneMode.Additive);
        }
    }

    public void LoadUnloadScene(string _loadSceneName)
    {
        LoadYourAsyncScene(_loadSceneName, LoadSceneMode.Additive);
    }

    public void UnloadUnloadScene(string _unloadSceneName)
    {
        if (SceneManager.GetSceneByName(_unloadSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(_unloadSceneName);
        }
    }

    IEnumerator LoadYourAsyncScene(string _sceneName, LoadSceneMode _mode)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);

        for (int i = 0; i < buildScenes.Count; i++)
        {
            SceneManager.LoadSceneAsync(buildScenes[i], LoadSceneMode.Additive);

        }

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
