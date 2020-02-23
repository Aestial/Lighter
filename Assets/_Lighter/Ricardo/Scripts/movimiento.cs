using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float thereshold = 0.0001f;

    // public Animator Animar;

    private Vector3 moveDirection = Vector3.zero;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //Animar = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            transform.LookAt(transform.position+moveDirection, Vector3.up);
            moveDirection *= speed;

            //if( moveDirection.magnitude > thereshold )
            //    {
            //    Animar.SetBool("IsWalking", true);
            //    }else Animar.SetBool("IsWalking", false);

            /*
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            */

            //if (Input.GetButton("Jump"))
            //{
            //    Animar.SetBool("IsPunching", true);
            //}else Animar.SetBool("IsPunching", false);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

    }
}