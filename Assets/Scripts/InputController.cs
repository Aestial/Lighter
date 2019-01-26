using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class InputController : MonoBehaviour 
{
    [SerializeField] private float speedMultiplier = 4f;

    public Rewired.Player rp { get { return ReInput.isReady ? ReInput.players.GetPlayer(0) : null; } }
    private Rigidbody rb;
    private InputDebugger inputDebugger;

    private float speed;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.inputDebugger = GetComponent<InputDebugger>();
    }

    void FixedUpdate()
    {
        
        if (!ReInput.isReady) return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.
        this.speed = this.speedMultiplier;
        Vector3 moveVector = Vector3.zero;
        moveVector.x = rp.GetAxis("Move Horizontal"); // get input by name or action id
        moveVector.z = rp.GetAxis("Move Vertical");
        bool fire = rp.GetButtonDown("Fire");

        if (moveVector != Vector3.zero)
        {
            this.rb.velocity = (moveVector * this.speed);
            this.transform.rotation = Quaternion.LookRotation(moveVector);
        }
        if (rp.GetButtonDown("Fire"))
        {
            // Do Shit
            this.inputDebugger.Fire(true);

        }
        else if (rp.GetButtonUp("Fire"))
        {
            // Stop Shit
            this.inputDebugger.Fire(false);
        }
    }

}
