using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameOutput : MonoBehaviour 
{
    [SerializeField] private MeshRenderer meshRenderer;
    //Material material;
    flameBehave flameBehave;
    public float currentHP;
	
	void Start () 
    {
        //this.material = this.meshRenderer.material;
        this.flameBehave = GetComponent<flameBehave>();
	}
	
	void Update () 
    {
        this.currentHP = this.flameBehave.actualHP;
        float t = this.currentHP / 100.0f;
        this.meshRenderer.material.color = Color.Lerp(Color.black, Color.yellow, t);
	}
}
