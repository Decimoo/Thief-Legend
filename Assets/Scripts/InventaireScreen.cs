using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventaireScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventaire inventaire;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    Dictionary<InventaireSlot, GameObject> itemsDisplayed = new Dictionary<InventaireSlot, GameObject>();
    public bool isEnabled;
    public Quaternion rotItem = new Quaternion();
    void Start()
    {
        CreateDisplay();
        isEnabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
       UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i <inventaire.Container.Count; i++)
        {
            var obj = Instantiate(inventaire.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventaire.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventaire.Container[i], obj); 
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i <inventaire.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventaire.Container[i]))
            {
                itemsDisplayed[inventaire.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventaire.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventaire.Container[i].item.prefab, Vector3.zero, Quaternion.identity , transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                Debug.Log(GetPosition(i));
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventaire.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventaire.Container[i], obj);           
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3((X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), (-Y_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), 0f);
    }
    public void OpenInventory()
    {
        this.gameObject.SetActive(true);
        isEnabled = true;
    }
    public void CloseInventory()
    {
        this.gameObject.SetActive(false);
        isEnabled = false;
    }

}

