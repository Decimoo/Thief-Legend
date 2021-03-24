using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chargement : MonoBehaviour {
    GameObject qui;

    public void CHARGEMENT () {

        // récupére le fichier.txt sus forme de tableau
        string[] penible = File.ReadAllText (Application.dataPath + "/sauvegarde.txt").Split (new [] { ":.:" }, System.StringSplitOptions.None);

        // gros switch
        foreach (var texte in penible) { string[] tab = texte.Split (new [] { ":-:" }, System.StringSplitOptions.None);

            if (tab[0] == "nom_de_la_scene" && PlayerPrefs.GetInt ("charger-le-reste") == 0) {
                PlayerPrefs.SetInt ("charger-le-reste", 1);
                SceneManager.LoadScene (tab[1]);
                return;
            }
            if (tab[0] == "Player") {
                qui = GameObject.FindWithTag("Player");
                // utiliser vector3 pour les positions
                qui.transform.position = new Vector3 (float.Parse (tab[1]), float.Parse (tab[2]), float.Parse (tab[3]));
            }
            if (tab[0] == "MainCamera")
            {
                qui = GameObject.FindWithTag("MainCamera");
                qui.transform.position = new Vector3 (float.Parse (tab[1]), float.Parse (tab[2]), float.Parse (tab[3]));
            }

        }
        PlayerPrefs.SetInt ("charger-le-reste", 0);
    }
}

// le playerpref "charger-le-reste" s'occuppe d'exécuter la bonne partie
// penser a le mettre a 0 en lançant le jeu
// ce script est lié au même game-object que le script jeu (c'est pratique) et donné en argument a celui ci
// la fonction start de jeu appelle donc chargement si "charger-le-reste" == 1 == un chargement est déja initié
