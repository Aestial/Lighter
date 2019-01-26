using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {

    public GameObject flama;

	void Start () {
        StartCoroutine(Cargar());
	}

    IEnumerator Cargar() {

        Vector3 posicion1 = new Vector3(-7.0f, 4.0f, 0.0f);
        Vector3 posicion2 = new Vector3(6.0f, 4.0f, 0.0f);

        Instantiate(flama, posicion1, transform.rotation);
        Instantiate(flama, posicion2, transform.rotation);

        yield return new WaitForSeconds(seconds: 0.0f);
    }


}
