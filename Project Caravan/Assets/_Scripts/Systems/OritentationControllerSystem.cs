using UnityEngine;
using System.Collections;
using Unity.Entities;

public class OritentationControllerSystem : ComponentSystem
{
    struct Characters
    {
        public readonly int Length;
        public ComponentArray<SpriteController> SpriteController;
        public ComponentArray<CharacterController> CharacterController;
    }

    [Inject] Characters CharactersData;

    protected override void OnUpdate()
    {
        for (int i = 0; i < CharactersData.Length; i++)
        {
            if (!CharactersData.SpriteController[i].spriteRenderer)
                return;

            if (CharactersData.CharacterController[i].horiziontal == 0)
            {
                break;
            }
            else if (CharactersData.CharacterController[i].horiziontal > 0)
            {
                CharactersData.SpriteController[i].spriteRenderer.flipX = true;
            }
            else
            {
                CharactersData.SpriteController[i].spriteRenderer.flipX = false;
            }
        }
    }
}
