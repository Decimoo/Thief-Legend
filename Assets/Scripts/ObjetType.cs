using UnityEngine;

public enum ItemType
{
    Item
}
public abstract class ObjetType : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string Name;
    

}
