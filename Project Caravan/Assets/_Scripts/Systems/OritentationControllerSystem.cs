using UnityEngine;
using System.Collections;
using Unity.Entities;

public class OritentationControllerSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((CharacterController controller, SpriteController spriteController, InteractionComponent interaction) =>
        {
            if (!spriteController.spriteRenderer)
                return;

            if (controller.horiziontal == 0)
            {
                return;
            }
            else if (controller.horiziontal > 0)
            {
                spriteController.spriteRenderer.flipX = true;
               interaction.flipX = 1;
            }
            else
            {
                spriteController.spriteRenderer.flipX = false;
               interaction.flipX = -1;
            }

        });
    }
}
