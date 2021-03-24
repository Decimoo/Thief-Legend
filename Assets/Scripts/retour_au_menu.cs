using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retour_au_menu : MonoBehaviour {

    public void Continue () {
        SceneManager.LoadScene ("menu-principal");
    }
}

// script simple qui va de pair avec la scéne victoire
// la fonction continue permet de retourner a la scéne menu-principal
// l'ajout de modifications pour les playerpref est possible