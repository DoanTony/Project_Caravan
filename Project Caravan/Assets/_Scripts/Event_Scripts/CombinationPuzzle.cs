using UnityEngine;
using System.Collections.Generic;

[SerializeField]    
public abstract class CombinationPuzzle<T> : MonoBehaviour
{
    public abstract List<T> requirementsCombination { get; }
}