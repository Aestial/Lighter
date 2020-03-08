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
        if (otherObj.attachedRigidbody)
            otherObj.attachedRigidbody.useGravity = false;

            otherObj.transform.position = Vector3.MoveTowards(otherObj.transform.position, endpoint.position, windSpeed * Time.deltaTime);
        Debug.Log("Collided with a Wind Collider");
    }

    private void OnTriggerExit(Collider otherObj)
    {
        otherObj.attachedRigidbody.useGravity = true;
        Debug.Log("Exit from a Wind Collider");
    }
}
