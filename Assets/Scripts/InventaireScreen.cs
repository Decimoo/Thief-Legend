using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventaireScreen : MonoBehaviour {
    public Inventaire inventaire;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    Dictionary<InventaireSlot, GameObject> itemsDisplayed = new Dictionary<InventaireSlot, GameObject> ();
    public bool isEnabled;

    void Start () {
        CreateDisplay ();
        isEnabled = true;
        X_SPACE_BETWEEN_ITEM = 1;
        NUMBER_OF_COLUMN = 5;

    }

    void Update () {
        UpdateDisplay ();
    }

    public void CreateDisplay () {
        for (int i = 0; i < inventaire.Container.Count; i++) {
            var obj = Instantiate (inventaire.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform> ().localPosition = GetPosition (i);
            obj.GetComponentInChildren<TextMeshProUGUI> ().text = inventaire.Container[i].amount.ToString ("n0");
            itemsDisplayed.Add (inventaire.Container[i], obj);
        }
    }

    public void UpdateDisplay () {
        for (int i = 0; i < inventaire.Container.Count; i++) {
            if (itemsDisplayed.ContainsKey (inventaire.Container[i])) {
                itemsDisplayed[inventaire.Container[i]].GetComponentInChildren<TextMeshProUGUI> ().text = inventaire.Container[i].amount.ToString ("n0");
            } else {
                var obj = Instantiate (inventaire.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform> ().localPosition = GetPosition (i);
                obj.GetComponentInChildren<TextMeshProUGUI> ().text = inventaire.Container[i].amount.ToString ("n0");
                itemsDisplayed.Add (inventaire.Container[i], obj);
            }
        }
    }

    public Vector3 GetPosition (int i) {
        return new Vector3 ((X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), 0f, 0f);
    }
    public void OpenInventory () {
        this.gameObject.SetActive (true);
        isEnabled = true;
    }
    public void CloseInventory () {
        this.gameObject.SetActive(false);
        isEnabled = false;
    }

}