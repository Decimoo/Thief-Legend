using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour {

    public GameObject panel;
    public AudioMixer audiomixer; //fait la liaison avec le son du jeu
    Resolution[] resolutions; //tableau des resolutions
    public Dropdown resolutionDropdown; //fait la liaison avec la resolution du jeu
    private void Start () {

        PlayerPrefs.SetInt ("charger-le-reste", 0);
        
        //met toutes les resolutions disponibles en fonction de l'écran ou il est lancé dans un tableau
        resolutions = Screen.resolutions.Select (resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct ().ToArray ();

        resolutionDropdown.ClearOptions (); //vire les options par défault, on peut les supprimer manuellement

        List<string> options = new List<string> (); //on doit changer le type de resolutions en string
        int currentresolutionindex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add (option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) {
                currentresolutionindex = i;
            }
        }
        resolutionDropdown.AddOptions (options);
        resolutionDropdown.value = currentresolutionindex; //resolution par defaut
        resolutionDropdown.RefreshShownValue ();

        Screen.fullScreen = true;
    }

    public void SetResolution (int resolutionindex) {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume) {
        audiomixer.SetFloat ("volume", volume);
    }

    public void SetFullScreen (bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }
    //
    //
    //
    //
    //
    //
    //
        public Canvas menulvl;
    public void StartGame () {

        menulvl.gameObject.SetActive (true);
        this.gameObject.SetActive (false);
    }

    public void OptionsGame () {
        panel.SetActive (true);
    }

    public void CloseOptionsGame () {
        panel.SetActive (false);
    }

    public void QuitGame () {
        Application.Quit ();
    }

}

// script servant de menu principal , lié a un canvas et des boutons