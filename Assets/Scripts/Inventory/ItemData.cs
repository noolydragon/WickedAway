using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string id;
    public string itemName;
    [TextArea] public string description;
    public Sprite icon;
    public bool isStackable = true;
    public int maxStackSize = 99;
}
