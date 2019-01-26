using UnityEngine;
using Sirenix.OdinInspector;
using Unity.Entities;

[RequireComponent(typeof(GameObjectEntity))]
public class CharacterController : MonoBehaviour
{
    public float movementSpeed;
    [ReadOnly]
    public float horiziontal;
}
