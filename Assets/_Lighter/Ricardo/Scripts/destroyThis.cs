using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyThis : MonoBehaviour
{
    public void OnTriggerEnter() 
    {
        Destroy(this.transform.parent.gameObject);
    }

}
