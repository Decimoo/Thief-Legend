using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Sauvegarde : MonoBehaviour
{
    public GameObject A;
    public GameObject[] SSS;
    public GameObject Camera;

    public void fun1()
    {
        A = GameObject.FindWithTag("Player"); // récupere les gameobject sans avoir besoin de les lier
        SSS = GameObject.FindGameObjectsWithTag("Ennemi"); // ne pas oublier le s si il y en a plusieurs
        Camera = GameObject.FindWithTag("MainCamera");
        Debug.Log(SSS.Length);

        List<string> penible = new List<string>() { // création d'une liste pour mettre toutes les données dedans : .Add pour en ajouter (ligne 30)
            "nom_de_la_scene"+":-:"+SceneManager.GetActiveScene().name,

            "test de sauvegarde", // A.transform.position renvoie les 3 positions avec des , ,je crois, à vérifier ca prendrais moins de place
            A.transform.tag.ToString()+":-:"+A.transform.position.x.ToString() + ":-:" +
            A.transform.position.y.ToString() + ":-:" + A.transform.position.z.ToString(),

            Camera.transform.tag.ToString()+":-:"+ Camera.transform.position.x.ToString() + ":-:" +
            Camera.transform.position.y.ToString() + ":-:" + Camera.transform.position.z.ToString(),
        };
        
        foreach(GameObject Value in SSS){

            penible.Add(Value.transform.name.ToString() + ":-:" + Value.transform.position.x.ToString() + ":-:" +
            Value.transform.position.y.ToString() + ":-:" + Value.transform.position.z.ToString());
        };

        string temp = string.Join(":.:", penible); // transforme le tableau en string

        File.WriteAllText(Application.dataPath + "/sauvegarde.txt", temp); // passe les données dans le fichier.txt

        Debug.Log(temp);
    }
}

// programme servant pour la sauvegarde
// ce script est relié a celui qui commande le joueur pour moi (appuyer sur s = sauvegarde)
//si tu as un menu dans le hud avec sauvegarde en option vas-y
// le fichier est sauvegardé en Application.dataPath, je sais pas trop ou c'est mais ca fontionne pour mes test
//le nom du fichier est sauvegarde.txt mais l'utilisation d'un playerpref qui contiendrais le nom serait plus indiqué pour de multiples sauvegardes
// l'utilisation de ":-:" et ":.:"  comme délimiteur c'étais pour les testes, si tu préfére : et ,

// le format de sauvegarde est :
//pour l'instant le nom de la scéne a charger est    "nom_de_la_scene"+":-:"+SceneManager.GetActiveScene().name
//toujour le premier sur la liste
//"nom pour check":-:données:-: ... :-:donnees:.:"nom pour check.....