using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject {

    [Header("Data information")]
    public new string name; // Item 

    [Header("Visual")]
    public Sprite sprite; // Item Sprite

}
