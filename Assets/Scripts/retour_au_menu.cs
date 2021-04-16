using UnityEngine;
using UnityEngine.SceneManagement;

public class retour_au_menu : MonoBehaviour {

    public void Continue () {
        SceneManager.LoadScene ("menu-principal");
    }
}