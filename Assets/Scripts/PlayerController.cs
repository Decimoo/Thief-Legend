using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sert pour changer de scene

public class PlayerController : MonoBehaviour
{
    public Inventaire inventaire;
    public HUDDisplay huddisplay;
    public Magic sort;
    public int mana;
    public bool bouger;
    public Play play;

    public Sauvegarde sav;
    void Awake()
    {
        mana = 9;
        bouger = false;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
    }

    public void Movement()
    {
        Vector3 pos = transform.position;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            if (DetectCollision())
            {
                pos.z += 1;
                transform.position = pos;
                bouger = true;
            }
        }

        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);
            if (DetectCollision())
            {
                pos.z -= 1;
                transform.position = pos;
                bouger = true;
            }

        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            if (DetectCollision())
            {
                pos.x += 1;
                transform.position = pos;
                bouger = true;
            }

        }
        
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
            if (DetectCollision())
            {
                pos.x -= 1;
                transform.position = pos;
                bouger = true;
            }

        }

        KeyBindings();

        if(bouger)
        {
            play.bloque = true;
            bouger = false;
            return;
        }
    }

    void KeyBindings()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (huddisplay.inventairescreen.isEnabled)
            {
                huddisplay.inventairescreen.CloseInventory();
            }
            else
            {
                huddisplay.inventairescreen.OpenInventory();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sav.fun1();
        }

    }

    bool DetectCollision()
    {   

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, 1) && hitInfo.transform.tag == "Obstacle")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       /* if(other.gameObject.CompareTag("Perdu"))
        {
            SceneManager.LoadScene("game-over");
        }*/
        
        if(other.gameObject.CompareTag("Gagne"))
        {
            SceneManager.LoadScene("victoire");
        }  
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            huddisplay.messagePanel.OpenMessagePanel(1);
            if(Input.GetKeyDown(KeyCode.F))
            {

                    var item = other.GetComponent<Objet>();
                    if(item)
                    {
                        inventaire.AddItem(item.objet, 1);
                        Destroy(other.gameObject);
                        huddisplay.messagePanel.CloseMessagePanel();
                    }
            }
        }
        
        else if(other.gameObject.CompareTag("Sort"))
        {
            sort = other.gameObject.GetComponent<Magic>();
            huddisplay.messagePanel.OpenMessagePanel(2);
            if(Input.GetKeyDown(KeyCode.F))
            {
                sort.ActiveMagie(other.gameObject, this);
                Destroy(other.gameObject, 3);
                huddisplay.messagePanel.CloseMessagePanel();
            }
        }
                 
    }
    void OnTriggerExit(Collider other)
    {
        huddisplay.messagePanel.CloseMessagePanel();
    }

    private void OnApplicationQuit()
    {
        inventaire.Container.Clear();

    }

}
