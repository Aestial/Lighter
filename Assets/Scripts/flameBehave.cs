using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameBehave : MonoBehaviour {

	// Use this for initialization

public GameObject player;

    int maxHP = 100;
    public int actualHP;
    public float fixedtime;
    Light flama;

    void Start()
    {
        flama = GetComponent<Light>();
        flama.range = maxHP/5;

        //fixedtime = 1f;
        this.actualHP = maxHP;
        StartCoroutine(Turnlight());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.actualHP = maxHP;
            StopAllCoroutines();
            StartCoroutine(Turnlight());
            Debug.Log("Touching flame");
        }
    }

    IEnumerator Turnlight()
    {
        while (actualHP > 0)
        {
            actualHP = actualHP - 1;
            flama.range = actualHP/5;
            //Debug.Log("flame: " + actualHP);
            yield return new WaitForSeconds(fixedtime);
        }


    }
}
