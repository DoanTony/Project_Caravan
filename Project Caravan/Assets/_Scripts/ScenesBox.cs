#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;

[ExecuteInEditMode]
public class ScenesBox : MonoBehaviour {
    public List<SceneAsset> scenes = new List<SceneAsset>();

    private void Awake()
    {
        StartCoroutine(LoadScenes());
        StartCoroutine(Execute());
    }

    private void OnValidate()
    {
      //  LoadScenes();
    }

    [ContextMenu("Load Scenes")]
    private IEnumerator LoadScenes()
    {
        if (EditorApplication.isPlaying)
        {
            yield return null;
        }
        else
        {
            foreach (SceneAsset scene in scenes)
            {
                if (scene)
                {
                    EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(scene), OpenSceneMode.Additive);
                    yield return null;
                }
            }
        }
    }

    public IEnumerator Execute()
    {
        EditorSceneManager.preventCrossSceneReferences = false;
        yield break;
    }
}
#endif