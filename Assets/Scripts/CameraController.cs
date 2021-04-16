using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private int CurrentCamera;
    public GameObject[] cameraList;
    public Play play;
    public PlayerController player;
    void Awake()
    {
        CurrentCamera = 0;
        cameraList = GameObject.FindGameObjectsWithTag("MainCamera");
        for (int i = 0; i < cameraList.Length; i++)
        {

            cameraList[i].gameObject.SetActive(false);
        }
        cameraList[CurrentCamera].gameObject.SetActive(true);

    }
    public void Update()
    {
    }
    public void ChangeCamera()
    {
        if (CurrentCamera == 0)
        {
            cameraList[CurrentCamera].gameObject.SetActive(false);
            CurrentCamera++;
            cameraList[CurrentCamera].gameObject.SetActive(true);
            play.GetComponent<Play> ().enabled = false;

        }
        else
        {
            cameraList[CurrentCamera].gameObject.SetActive(false);
            CurrentCamera--;
            cameraList[CurrentCamera].gameObject.SetActive(true);
            play.GetComponent<Play> ().enabled = true;
        }
    }
    public void Controller()
    {
        Debug.Log("1");
        Vector3 pos = transform.position;
        if (Input.GetKeyDown (KeyCode.G)) {
            Debug.Log("haut");
            pos.z += 1;
            this.transform.position = pos;
        }

        if (Input.GetKeyDown (KeyCode.DownArrow)) {
            pos.z -= 1;
            this.transform.position = pos;

        }
        if (Input.GetKeyDown (KeyCode.RightArrow)) {
             pos.x += 1;
            transform.position = pos;

        }
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
             pos.x -= 1;
            transform.position = pos;

        }
        if (Input.GetKeyDown (KeyCode.E)) {

            
        }
    }
}
