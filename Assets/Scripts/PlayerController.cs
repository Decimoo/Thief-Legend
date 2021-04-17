using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sert pour changer de scene

public class PlayerController : MonoBehaviour {
    public Inventaire inventaire;
    public HUDDisplay huddisplay;
    public Magic sort;
    public int mana;
    public bool bouger;
    public Play play;
    public Sauvegarde sav;
    public PauseMenu pausemenu;
    private int CurrentCamera;
    public GameObject[] cameraList;
    void Awake () {
        mana = 9;
        bouger = false;
        CurrentCamera = 0;
        cameraList = GameObject.FindGameObjectsWithTag("MainCamera");
        for (int i = 0; i < cameraList.Length; i++)
        {

            cameraList[i].gameObject.SetActive(false);
        }
        cameraList[CurrentCamera].gameObject.SetActive(true);

    }

    public void FixedUpdate () {
    }

    public void Movement () {
        Vector3 pos = transform.position;
        if (Input.GetKeyDown (KeyCode.UpArrow)) {
            Vector3 direction = new Vector3 (transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
            StartCoroutine (Tourne (direction, 1));
            if (DetectCollision ()) {
                pos.z += 6;
                transform.position = pos;
                bouger = true;
            }
        }
        if (Input.GetKeyDown (KeyCode.DownArrow)) {
            Vector3 direction = new Vector3 (transform.rotation.eulerAngles.x, -180, transform.rotation.eulerAngles.z);
            StartCoroutine (Tourne (direction, 2));
            if (DetectCollision ()) {
                pos.z -= 6;
                transform.position = pos;
                bouger = true;
            }

        }
        if (Input.GetKeyDown (KeyCode.RightArrow)) {
            Vector3 direction = new Vector3 (transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z);
            StartCoroutine (Tourne (direction, 3));
            if (DetectCollision ()) {
                pos.x += 6;
                transform.position = pos;
                bouger = true;
            }

        }
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            Vector3 direction = new Vector3 (transform.rotation.eulerAngles.x, -90, transform.rotation.eulerAngles.z);
            StartCoroutine (Tourne (direction, 4));
            if (DetectCollision ()) {
                pos.x -= 6;
                transform.position = pos;
                bouger = true;
            }

        }

        KeyBindings ();

        if (bouger) {
            play.bloque = true;
            bouger = false;
            return;
        }
    }

    void KeyBindings () {
        if (Input.GetKeyDown (KeyCode.I)) {
            if (huddisplay.inventairescreen.isEnabled) {
                huddisplay.inventairescreen.CloseInventory ();
            } else {
                huddisplay.inventairescreen.OpenInventory ();
            }
        }
        if (Input.GetKeyDown (KeyCode.S)) {
            sav.SAUVEGARDE ();
        }
        if (Input.GetKeyDown (KeyCode.E)) {
            ChangeCamera();

        }

        if (Input.GetKeyDown (KeyCode.Escape)) {

            if (pausemenu.GameIsPaused) {
                pausemenu.Resume ();
            } else {
                pausemenu.Pause ();

            }
        }

    }

    public IEnumerator Tourne (Vector3 cible, int dir) {
        float maxangle, minangle;
        play.GetComponent<Play> ().enabled = false;
        if (dir == 1) {
            maxangle = 0.002f;
            minangle = -0.002f;
            while (this.gameObject.transform.rotation.y < minangle || this.gameObject.transform.rotation.y > maxangle) {

                Quaternion targetRotation = Quaternion.Euler (cible);
                this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.time / 75);
                yield return new WaitForEndOfFrame ();
            }
        } else if (dir == 2) {
            maxangle = 0.9999f;
            minangle = -0.9999f;
            while (this.gameObject.transform.rotation.y > minangle && this.gameObject.transform.rotation.y < maxangle) {

                Quaternion targetRotation = Quaternion.Euler (cible);
                this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.time / 75);
                yield return new WaitForEndOfFrame ();
            }
        } else if (dir == 3) {
            maxangle = -0.69f;
            minangle = -0.71f;
            while (!(minangle < this.gameObject.transform.rotation.y && this.gameObject.transform.rotation.y < maxangle) && !(-maxangle < this.gameObject.transform.rotation.y && this.gameObject.transform.rotation.y < -minangle)) {
                Quaternion targetRotation = Quaternion.Euler (cible);
                this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.time / 75);
                yield return new WaitForEndOfFrame ();
            }
        } else if (dir == 4) {
            maxangle = -0.69f;
            minangle = -0.71f;
            while (!(minangle < this.gameObject.transform.rotation.y && this.gameObject.transform.rotation.y < maxangle) && !(-maxangle < this.gameObject.transform.rotation.y && this.gameObject.transform.rotation.y < -minangle)) {
                Quaternion targetRotation = Quaternion.Euler (cible);
                this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.time / 75);
                yield return new WaitForEndOfFrame ();
            }
        }
        play.GetComponent<Play> ().enabled = true;
    }

    bool DetectCollision () {

        Vector3 posray = transform.position; 
        posray.y -=10;
        Ray ray = new Ray (posray, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast (ray, out hitInfo, 8) && hitInfo.transform.tag == "Obstacle") 
        {
            Debug.Log("Touche");
            return false; 
        }

        return true;
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Gagne")) { SceneManager.LoadScene ("victoire"); }
    }
    void OnTriggerStay (Collider other) {
        if (other.gameObject.CompareTag ("Item")) {
            huddisplay.messagePanel.OpenMessagePanel (1);
            if (Input.GetKeyDown (KeyCode.F)) {

                var item = other.GetComponent<Objet> ();
                if (item) {
                    inventaire.AddItem (item.objet, 1);
                    Destroy (other.gameObject);
                    huddisplay.messagePanel.CloseMessagePanel ();
                }
            }
        }

        if (other.gameObject.CompareTag ("Sort")) {
            sort = other.gameObject.GetComponent<Magic> ();
            huddisplay.messagePanel.OpenMessagePanel (2);
            if (Input.GetKeyDown (KeyCode.F)) {
                sort.ActiveMagie (other.gameObject, this);
                Destroy (other.gameObject, 3);
                huddisplay.messagePanel.CloseMessagePanel ();
            }
        }

        if (other.gameObject.CompareTag ("Monter")) {
            huddisplay.messagePanel.OpenMessagePanel (3);
            if (Input.GetKeyDown (KeyCode.F)) {
                StartCoroutine(Climb(other.gameObject));
                huddisplay.messagePanel.CloseMessagePanel ();
            }
        }

    }
      public void ChangeCamera()
    {
        if (CurrentCamera == 0)
        {
            cameraList[CurrentCamera].gameObject.SetActive(false);
            CurrentCamera++;
            cameraList[CurrentCamera].gameObject.SetActive(true);

        }
        else
        {
            cameraList[CurrentCamera].gameObject.SetActive(false);
            CurrentCamera--;
            cameraList[CurrentCamera].gameObject.SetActive(true);
        }
    }
    public IEnumerator Climb(GameObject Monte)
    {
        float timer = 0;
        Vector3 startpos = transform.position;
        enabled = false;
        GameObject obj = Monte.transform.GetChild(0).gameObject;
        while(timer < 3)
        {
            transform.position = Vector3.Lerp(startpos, obj.transform.position,timer/3);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        enabled = true;
    } 
    void OnTriggerExit (Collider other) { huddisplay.messagePanel.CloseMessagePanel (); }
    private void OnApplicationQuit () { inventaire.Container.Clear (); }

}