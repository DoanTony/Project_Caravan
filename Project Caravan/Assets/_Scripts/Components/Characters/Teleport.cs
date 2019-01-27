using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public void TeleportTarget(Transform _transform)
    {
        this.transform.position = _transform.position;
    }
}
