using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public void Reessayer()
    {
        SceneManager.LoadScene( PlayerPrefs.GetString ("reessayer"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}