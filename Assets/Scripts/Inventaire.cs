using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventaireSlot
{
    public ObjetType item;
    public int amount;
    public InventaireSlot(ObjetType _item, int _amount)
    {
        item = _item;
        amount = _amount;     
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventaire : ScriptableObject
{
    public List<InventaireSlot> Container = new List<InventaireSlot>();
    public void AddItem(ObjetType _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        
        if (!hasItem)
        {
            Container.Add(new InventaireSlot(_item, _amount));
        }

    }
}
