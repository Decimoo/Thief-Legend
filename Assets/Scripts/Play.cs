using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public PlayerController player;
    public List<GameObject> ennemies;
    public Enemy ennemi;
    public int nbTour;
    public int nbPlayers;
    public bool bloque;
    public Chargement chargement;
    public HUDDisplay HUD;


    void Awake()
    {
    }
    //cette partie consiste à récuperer les pions (personnage principale + ennemis).
    //elle implique que les pions se trouvent dans le dossier (child = enfant).
    //si cela n'est pas possible, on peut les rentrer manuellement 1 par 1

    // Start is called before the first frame update
    void Start()
    {
        nbTour = 1;
        ennemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ennemi"));
        nbPlayers = ennemies.Count + 1;
        bloque = false;
        if (PlayerPrefs.GetInt("charger-le-reste") == 1)
        {
            chargement.CHARGEMENT();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(bloque == false)
        {
            player.Movement();
            for(int i = 0; i < ennemies.Count; i++)
            {
                ennemi = ennemies[i].GetComponent<Enemy>();
                ennemi.GetComponent<Enemy>().enabled = false;
            }
        }
        else if (bloque == true)
        {
            for(int i = 0; i < ennemies.Count; i++)
            {
                ennemi.GetComponent<Enemy>().enabled = true;
                ennemi = ennemies[i].GetComponent<Enemy>();
                ennemi.EnnemiDeplacement();
            }
            bloque = false;
            nbTour++;
            HUD.Tours.text = "Tour n°"+ nbTour;
        }
    }

}
