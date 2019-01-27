using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedor : MonoBehaviour {

    private float moveSpeed;
	// Use this for initialization
	void Start () {
        moveSpeed = 12.0f;
    }

    // Update is called once per frame
    void Update() {

        float velx = Input.GetAxis("Vertical") * moveSpeed;
        float vely = Input.GetAxis("Horizontal") * moveSpeed;

        transform.Translate(Vector3.forward * velx * Time.deltaTime);
        transform.Translate(Vector3.right * vely * Time.deltaTime);

    }
}
