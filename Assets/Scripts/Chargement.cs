using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chargement : MonoBehaviour {
    private GameObject qui; //nom du gameObject a charger

    public void CHARGEMENT () {

        string[] sauvegarde = File.ReadAllText (Application.dataPath + "/sauvegarde.txt").Split (new [] { ":.:" }, System.StringSplitOptions.None);

        foreach (var texte in sauvegarde) {
            string[] tab = texte.Split (new [] { ":-:" }, System.StringSplitOptions.None);

            if (tab[0] == "nom_de_la_scene" && PlayerPrefs.GetInt ("charger-le-reste") == 0) {
                PlayerPrefs.SetInt ("charger-le-reste", 1);
                SceneManager.LoadScene (tab[1]);
                return;
            }

            if (tab[0] == "Player") {
                qui = GameObject.FindWithTag ("Player");
                // utiliser vector3 pour les positions
                qui.transform.position = new Vector3 (float.Parse (tab[1]), float.Parse (tab[2]), float.Parse (tab[3]));
            }
            if (tab[0] == "MainCamera") {
                qui = GameObject.FindWithTag ("MainCamera");
                qui.transform.position = new Vector3 (float.Parse (tab[1]), float.Parse (tab[2]), float.Parse (tab[3]));
            }

        }
        PlayerPrefs.SetInt ("charger-le-reste", 0);
    }
}

// le playerpref "charger-le-reste" s'occuppe d'exécuter la bonne partie
// penser a le mettre a 0 en lançant le jeu
