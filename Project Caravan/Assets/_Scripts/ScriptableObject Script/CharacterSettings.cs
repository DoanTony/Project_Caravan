using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings",menuName = "Character/Setting", order = 0)]
public class CharacterSettings : ScriptableObject
{
    public bool lockMovements;

    private void OnEnable()
    {
        lockMovements = false;
    }

    private void OnDisable()
    {
        lockMovements = false;
    }

    public void LockMovements()
    {
        lockMovements = true;
    }

    public void UnlockMovements()
    {
        lockMovements = false;
    }
}
