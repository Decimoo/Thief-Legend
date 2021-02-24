using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detection : MonoBehaviour
{
    public Transform player;
    public float maxAngle;
    public float maxRadius;

    public bool isInFov = false;

    private void OnDrawGizmos()
    {
    /*    Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);*/

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (isInFov == false)
            Gizmos.color = Color.red;
        if (isInFov == true)
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

    /*    Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);*/


    }

    public void inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Vector3 directionBetween = (target.position - checkingObject.position).normalized;
        directionBetween.y *= 0;

        RaycastHit hit;
        if (Physics.Raycast(checkingObject.position + Vector3.zero, (target.position - checkingObject.position).normalized, out hit, maxRadius))
        {
            if (hit.transform.tag == "Player")
            {
                float angle = Vector3.Angle(checkingObject.forward + Vector3.zero, directionBetween);

                if (angle <= maxAngle)
                {
                    isInFov = true;
                    SceneManager.LoadScene("game-over");
                }
                else
                {
                    isInFov = false;
                }
            }
            else
            {
                isInFov = false;
            }
        }
       
    }

    private void FixedUpdate()
    {

        inFOV(transform, player, maxAngle, maxRadius);

    }

}