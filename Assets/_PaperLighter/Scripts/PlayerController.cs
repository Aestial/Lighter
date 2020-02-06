using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public bool canInteract;
    [SerializeField] private string interactionTag;
    public GameObject currentInteractive;
    public float currentHP = 1.0f;
    public float speed;
    public Vector2 direction;
    //[SerializeField] float drainSpeed = 0.5f;

    private new Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.currentInteractive = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentHP > 0.0f)
            //currentHP -= drainSpeed * Time.deltaTime;

        this.speed = this.rigidbody.velocity.magnitude;
        float x = this.rigidbody.velocity.normalized.x;
        float y = this.rigidbody.velocity.normalized.z;
        this.direction = new Vector2(x, y);
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
