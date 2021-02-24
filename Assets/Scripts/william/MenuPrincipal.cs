using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //public string levelToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"/*levelToLoad*/);
    }

//  public void OptionsGame()
//  {
//  
//  }

    public void QuitGame()
    {
        Application.Quit();
    }
}
