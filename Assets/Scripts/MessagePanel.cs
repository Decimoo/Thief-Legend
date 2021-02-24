using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessagePanel : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        messagePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenMessagePanel(int num)
    {
        if(num == 1)
        {
            text.text = "Appuyez sur F pour ramasser l'objet";
        }
        else if (num == 2)
        {
            text.text = "Appuyez sur F pour utiliser un sort";
        }
        messagePanel.SetActive(true);
        
    }
    public void CloseMessagePanel()
    {
        messagePanel.SetActive(false);
    }
}
