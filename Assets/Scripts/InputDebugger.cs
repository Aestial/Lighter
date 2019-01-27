using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDebugger : MonoBehaviour 
{
    [SerializeField] private Color fireColor;
    [SerializeField] private Color normalColor;
    //private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () 
    {
        //this.meshRenderer = GetComponent<MeshRenderer>();
        //this.meshRenderer.material.color = normalColor;
	}

    public void Fire(bool isActive)
    {
        //this.meshRenderer.material.color = isActive ? fireColor : normalColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
