using UnityEngine.UI;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menulvl : MonoBehaviour {

    public Canvas mainmenu;
    public Chargement Charger;

    public Text text;

    public void Newgame () {
        File.Delete (Application.dataPath + "/sauvegarde.txt");
        SceneManager.LoadScene ("Niveau1-1");
    }

    public void Retour () {

        mainmenu.gameObject.SetActive (true);
        this.gameObject.SetActive (false);
    }

    public void Continuer () {

        if (!File.Exists (Application.dataPath + "/sauvegarde.txt")) {
            this.transform.GetChild(3).gameObject.SetActive(true);
              this.transform.GetChild(1).gameObject.SetActive(false);
            text.text = "le fichier " + Application.dataPath + "/sauvegarde.txt " + " n'existe pas";
          
            }

        else {Charger.CHARGEMENT ();}

    }

}