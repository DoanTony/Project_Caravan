using UnityEngine;
using System.Collections;
using Unity.Entities;

public class CharacterControllerSystem : ComponentSystem
{
    struct Characters
    {
        public readonly int Length;
        public ComponentArray<Character> Character;
        public ComponentArray<CharacterController> Controller;
        public ComponentArray<Transform> Transform;
    }

    [Inject] Characters CharactersData;

    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;
        for (int i = 0; i < CharactersData.Length; i++)
        {
            HorizontalInput(ref CharactersData.Controller[i].horiziontal);
            Move(CharactersData.Controller[i], CharactersData.Transform[i], dt);
        }
    }

    private void HorizontalInput(ref float _horizontal)
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void Move(CharacterController _controller, Transform _transform, float _dt)
    {
        Vector3 horizontalDir = Vector3.right * _controller.horiziontal;
        Vector3 forward = horizontalDir * _controller.movementSpeed * _dt;
        _transform.Translate(forward);
    }
}
