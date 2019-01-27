using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameBehave : MonoBehaviour {

	// Use this for initialization

public GameObject player;
public GameObject healthBar;

    int maxHP = 100;
    public int actualHP;
    public float fixedtime;
    float healthBarPercnt; 
    Light flama;

    void Start()
    {
        flama = GetComponent<Light>();
        flama.range = maxHP/5;

        fixedtime = 1f;
        this.actualHP = maxHP;

        healthBarPercnt = (float)this.actualHP / (float)maxHP;

        StartCoroutine(Turnlight());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            this.actualHP = maxHP;
            healthBarPercnt = 1.0f;
            SetHealthBarSize(healthBarPercnt);
            //Debug.Log("Touching flame");
        }
    }

    void SetHealthBarSize(float Percentage)
    {
        healthBar.transform.localScale = new Vector3(Percentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    IEnumerator Turnlight()
    {
        while (actualHP > 0)
        {
            actualHP = actualHP - 1;
            flama.range = actualHP/5;
            healthBarPercnt = (float)this.actualHP / (float)maxHP;
            SetHealthBarSize(healthBarPercnt);

            //Debug.Log("flame: " + actualHP);
            yield return new WaitForSeconds(fixedtime);
        }


    }
}
