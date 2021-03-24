using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public void Reessayer()
    {
        SceneManager.LoadScene("niveau-1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

// script lié avec la scéne : "game over"
// la ligne 10  devra étre modifiée par un player pref pour le nom du niveau