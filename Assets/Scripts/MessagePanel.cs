using UnityEngine;
using TMPro;
public class MessagePanel : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI text;
    void Start()
    {
        messagePanel.SetActive(false);
    }


    public void OpenMessagePanel(int num)
    {
        if(num == 1)
        {
            text.text = "Appuyez sur F pour ramasser l'objet";
        }
        if (num == 2)
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
