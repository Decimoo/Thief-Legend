using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDDisplay : MonoBehaviour
{
    public Play play;
    public InventaireScreen inventairescreen;
    public MessagePanel messagePanel;
    
    public Mana_image fleur;

    public PlayerController player;

    public TextMeshProUGUI LevelName;
    public TextMeshProUGUI Tours;
    void Start()
    {
        LevelName.text = SceneManager.GetActiveScene().name;
        Tours.text = "Tour n°"+ play.nbTour;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int Changer_mana(int Changer)
    {
        if (Changer < 0)
        {
            for (int i = 0; player.mana > 0 && i < -Changer; i++)
            {
                fleur.simages[player.mana].gameObject.SetActive(false);
                player.mana--;
                fleur.simages[player.mana].gameObject.SetActive(true);
            }
        }

        if (Changer > 0)
        {
            for (int i = 0; player.mana < 9 && i < Changer; i++)
            {
                fleur.simages[player.mana].gameObject.SetActive(false);
                player.mana++;
                fleur.simages[player.mana].gameObject.SetActive(true);
            }
        }
        return player.mana;
    }
}
