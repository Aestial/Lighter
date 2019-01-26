using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour 
{
    public bool canInteract;
    [SerializeField] private string interactionTag;
    public GameObject currentInteractive;

    // Use this for initialization
    void Start()
    {
        this.currentInteractive = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        //this.currentInteractive.GetComponent<InteractiveController>().Action();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == interactionTag)
        {
            this.canInteract = true;
            this.currentInteractive = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == interactionTag)
        {
            this.canInteract = false;
            this.currentInteractive = null;
        }
    }
}
