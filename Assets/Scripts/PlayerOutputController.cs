using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutputController : MonoBehaviour 
{
    PlayerControler playerControler;
    Light light;

	// Use this for initialization
	void Start () 
    {
        light = GetComponent<Light>();
        playerControler = GetComponent<PlayerControler>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.light.intensity = playerControler.currentHP/20;
	}
}
