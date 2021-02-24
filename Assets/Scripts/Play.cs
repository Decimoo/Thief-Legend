using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public PlayerController player;
    public List<GameObject> ennemies;
    public Enemy ennemi;
    public int nbTour;


    void Awake()
    {
    }
    //cette partie consiste à récuperer les pions (personnage principale + ennemis).
    //elle implique que les pions se trouvent dans le dossier (child = enfant).
    //si cela n'est pas possible, on peut les rentrer manuellement 1 par 1

    // Start is called before the first frame update
    void Start()
    {
        nbTour = 1;
        ennemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ennemi"));
    }

    // Update is called once per frame
    void Update()
    {
        player.Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < ennemies.Count; i++)
            {
                ennemi = ennemies[i].GetComponent<Enemy>();
                ennemi.EnnemiDeplacement();
            }
            nbTour++;
            Debug.Log(nbTour);
        }
    }

}
