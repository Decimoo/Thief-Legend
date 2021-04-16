using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void EnnemiDeplacement()
    {
        Vector3 pos = transform.position;
        if(transform.rotation.eulerAngles.y == 0)
        {
            pos.z += 1;
            transform.position = pos;
        }

        else if(transform.rotation.eulerAngles.y == 90)
        {
            pos.x += 1;
            transform.position = pos;
        }

        else if(transform.rotation.eulerAngles.y == 180)
        {
            pos.z -= 1;
            transform.position = pos;
        }

        else if(transform.rotation.eulerAngles.y == 270)
        {
            pos.x -= 1;
            transform.position = pos;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Balise"))
        {
            transform.eulerAngles = new Vector3(col.transform.rotation.eulerAngles.x, col.transform.rotation.eulerAngles.y, col.transform.rotation.eulerAngles.z);
        }
    }


}
