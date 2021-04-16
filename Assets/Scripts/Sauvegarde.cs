using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Sauvegarde : MonoBehaviour
{
    private GameObject PLAYER;
    private GameObject[] ENNEMIS;
    private GameObject CAMERA;

    public void SAUVEGARDE()
    {
        PLAYER = GameObject.FindWithTag("Player");
        ENNEMIS = GameObject.FindGameObjectsWithTag("Ennemi");
        CAMERA = GameObject.FindWithTag("MainCamera");

        List<string> result = new List<string>() {

            "nom_de_la_scene"+":-:"+SceneManager.GetActiveScene().name,

            PLAYER.transform.tag+":-:"+PLAYER.transform.position.x+ ":-:"+PLAYER.transform.position.y+":-:"+PLAYER.transform.position.z,

            CAMERA.transform.tag+":-:"+CAMERA.transform.position.x+ ":-:"+CAMERA.transform.position.y+":-:"+CAMERA.transform.position.z,
        };
        
        foreach(GameObject Value in ENNEMIS){result.Add(Value.transform.name+":-:"+Value.transform.position.x+":-:"+Value.transform.position.y+":-:"+Value.transform.position.z);};

        File.WriteAllText(Application.dataPath + "/sauvegarde.txt", string.Join(":.:", result));

    }
}

// utilisation de ":-:" comme delimiteur pour les differentes variables des gamesObjects
// utilisation de ":.:" comme delimiteur pour les differents gameObjects