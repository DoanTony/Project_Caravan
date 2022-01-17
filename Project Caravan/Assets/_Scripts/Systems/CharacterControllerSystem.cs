using UnityEngine;
using System.Collections;
using Unity.Entities;

public class CharacterControllerSystem : ComponentSystem
{

    protected override void OnUpdate()
    {

        float dt = Time.DeltaTime;

        Entities.ForEach((Character entity, CharacterController controller, Transform transform) =>
        {
            if (!entity.setting.lockMovements && controller.IsActive)
            if (!entity.setting.lockMovements && controller.IsActive)
            {
                HorizontalInput(ref controller.horiziontal);
                Move(controller, transform, dt);
            }

        });
       
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
