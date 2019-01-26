using UnityEngine;

public interface IFieldOfVision
{
    float radius { get; }
    bool showGizmo { get;  set; }
    LayerMask layerMask { get; set; }
}