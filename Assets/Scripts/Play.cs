using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
    public PlayerController player;
    public List<GameObject> ennemies;
    public int nbTour;
    public int nbPlayers;
    public bool bloque;
    public Chargement chargement;
    public HUDDisplay HUD;

    void Start () {
        nbTour = 1;
        ennemies = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Ennemi"));
        nbPlayers = ennemies.Count + 1;
        bloque = false;

        if (PlayerPrefs.GetInt ("charger-le-reste") == 1) { chargement.CHARGEMENT (); }
        
         PlayerPrefs.SetString ("reessayer", SceneManager.GetActiveScene().name);
    }

    void Update () {
        if (bloque == false) {

            for (int i = 0; i < ennemies.Count; i++) { ennemies[i].GetComponent<Enemy> ().enabled = false; }
            player.Movement ();

        } 
        else {
            for (int i = 0; i < ennemies.Count; i++) {
               ennemies[i].GetComponent<Enemy> ().enabled = true;
                ennemies[i].GetComponent<Enemy> ().EnnemiDeplacement ();
            }
            bloque = false;
            nbTour++;
            HUD.Tours.text = "Tour n°" + nbTour;
        }
    }
}

// bloque force l'exécution des scripts les uns après les autres au lieu qu'ils soient simultanés