using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Unity.Entities;

[RequireComponent(typeof(ConvertToEntity))]
public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    [ReadOnly]
    public float horiziontal;

    public bool IsActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }

    public void SetActive(bool active)
    {
        IsActive = active;
    }
}
