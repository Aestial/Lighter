using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour {

	// Use this for initialization

    public GameObject player;
    [SerializeField] float cost = 0.25f;
    [SerializeField] float drainSpeed = 0.01f;
    [SerializeField] float debounceTime = 1.0f;
    [SerializeField] AudioClip fireSound;

    public float drainMultiplier = 1.0f;

    float maxHP = 1.0f;
    public float actualHP;
    public float fixedtime;

    bool debounce = false;

    void Start()
    {
        //fixedtime = 1f;
        this.actualHP = maxHP;
        StartCoroutine(Turnlight());
    }

    void OnTriggerEnter(Collider other)
    {
        if (!debounce && actualHP > 0.0f && other.gameObject.name == "Player")
        {
            float playerHP = other.GetComponent<PlayerController>().currentHP;
            if (playerHP >= cost)
            {
                debounce = true;
                this.actualHP = maxHP;
                StopAllCoroutines();
                StartCoroutine(Turnlight());
                StartCoroutine(DebounceCoroutine());
                Debug.Log("Touching flame");
                other.GetComponent<PlayerController>().currentHP -= cost;
                AudioManager.Instance.PlayOneShoot2D(fireSound);
            }
        }
    }

    IEnumerator DebounceCoroutine()
    {
        yield return new WaitForSeconds(debounceTime);
        debounce = false;
    }

    IEnumerator Turnlight()
    {
        while (actualHP > 0)
        {
            actualHP = actualHP - (drainSpeed * drainMultiplier);
            //Debug.Log("flame: " + actualHP);
            yield return new WaitForSeconds(fixedtime);
        }
    }
}
