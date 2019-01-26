using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameBehave : MonoBehaviour {

	// Use this for initialization

public GameObject player;

    int maxHP = 1000;
    public int actualHP;
    public float fixedtime;

    void Start()
    {
        fixedtime = 1f;
        this.actualHP = maxHP;
        StartCoroutine(Turnlight());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.actualHP = maxHP;
            Debug.Log("Touching flame");
        }
    }

    IEnumerator Turnlight()
    {
        while (actualHP > 0)
        {
            actualHP = actualHP - 1;
            Debug.Log("flame: " + actualHP);
            yield return new WaitForSeconds(fixedtime);
        }


    }
}
