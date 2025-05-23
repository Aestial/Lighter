using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTouch : MonoBehaviour {

    [SerializeField] float maxHP = 1.0f;
    //public float actualHP;
    //public float fixedtime;
    PlayerController playerController;
    [SerializeField] AudioClip fireSound;

    public GameObject fuente;
    
    void Start () {
        //fixedtime = 1f;
        //this.actualHP = maxHP;
        //StartCoroutine(Lowerlight());
        this.playerController = GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Source")
        {
            this.playerController.currentHP = maxHP;
            AudioManager.Instance.PlayOneShoot2D(fireSound);
            //this.actualHP = maxHP;
            Debug.Log("Charging!");

        }
    }

    //IEnumerator Lowerlight()
    //{
    //    while (actualHP > 0)
    //    {
    //        actualHP = actualHP -1;
    //        yield return new WaitForSeconds(fixedtime);
    //    }

    
    //}

}
