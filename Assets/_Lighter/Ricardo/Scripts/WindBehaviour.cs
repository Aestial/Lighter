using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehaviour : MonoBehaviour
{
    public GameObject wind;
    public Transform endpoint;
    public float windSpeed;
   

    void OnTriggerStay(Collider otherObj)
    {
        otherObj.transform.position = Vector3.MoveTowards(otherObj.transform.position, endpoint.position, windSpeed * Time.deltaTime);
        Debug.Log("Collided with a Wind Collider");
    }
}
