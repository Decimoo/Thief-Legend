using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObjet : ObjetType
{
    void Awake()
    {
        type = ItemType.Item;
    }
}
