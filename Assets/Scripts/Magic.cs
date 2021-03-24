using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Magic : MonoBehaviour
{
    public HUDDisplay mana;

    public void ActiveMagie(GameObject magictag, PlayerController player)
    {
        if(magictag.name == "PDL")
        {   
            GameObject pont = magictag.transform.GetChild(0).gameObject;
            GameObject mur = magictag.transform.GetChild(1).gameObject;
            GameObject pointarrive = magictag.transform.GetChild(2).gameObject;
            if(pont.CompareTag("PontPDL"))
            {
                mana.Changer_mana(-1);
                pont.SetActive(true);
                pont.transform.parent = GameObject.Find("Sorts").transform;
                pointarrive.transform.parent = GameObject.Find("Sorts").transform;
                Destroy(mur);
                StartCoroutine(Climb(player,pointarrive));
            }
        }
    }
    public IEnumerator Climb(PlayerController player, GameObject obj)
    {
        float timer = 0;
        Vector3 startpos = player.transform.position;
        player.enabled = false;
        while(timer < 3)
        {
            player.transform.position = Vector3.Lerp(startpos, obj.transform.position,timer/3);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        player.enabled = true;
    }
}
