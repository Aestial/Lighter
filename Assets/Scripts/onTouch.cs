using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTouch : MonoBehaviour {

    int maxHP = 1000;
    public int actualHP;
    public float fixedtime;

    public GameObject fuente;
    
    void Start () {
        fixedtime = 1f;
        this.actualHP = maxHP;
        StartCoroutine(Lowerlight());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Source")
        {
            this.actualHP = maxHP;
            Debug.Log("Touching!");

        }
    }

    IEnumerator Lowerlight()
    {
        while (actualHP > 0)
        {
            actualHP = actualHP -1;
            yield return new WaitForSeconds(fixedtime);
        }

    
    }

}
