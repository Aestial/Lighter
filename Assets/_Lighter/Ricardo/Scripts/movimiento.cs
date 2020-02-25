using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    //private  CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    //public float gravity = 75.0f;
    
    // public Animator Animar;

    private Vector3 moveVelocity = Vector3.zero;
    private Rigidbody body;

    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        //Animar = gameObject.GetComponentInParent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveVelocity = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        transform.LookAt(transform.position+moveVelocity, Vector3.up);
        moveVelocity *= speed * Time.deltaTime;
        //moveVelocity.y -= gravity * Time.deltaTime;
        moveVelocity.y = body.velocity.y;
        body.velocity = moveVelocity;

    }
}