using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutputController : MonoBehaviour 
{
    [SerializeField] float startSpeedThreshold;
    [SerializeField] Animator animator;
    [SerializeField] Light light;
    PlayerControler playerControler;
    //Light light;
    //[SerializeField] Animator animator;

    public float speed;
    public Vector2 direction;
    public bool isHorizontal;
    public bool isUp;
    public bool isDown;

	// Use this for initialization
	void Start () 
    {
        //animator = GetComponent<Animator>();
        //light = GetComponent<Light>();
        playerControler = GetComponent<PlayerControler>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = playerControler.speed;
        direction = playerControler.direction;

        if (speed > startSpeedThreshold)
        {
            animator.SetFloat("Speed", speed);
        }
        //float x = (direction.x >= direction.y) ? Mathf.Sign(direction.x) : 0;
        //float y = (direction.x < direction.y) ? Mathf.Sign(direction.y) : 0;

        isHorizontal = Mathf.Abs(direction.x) >= Mathf.Abs(direction.y);
        Debug.Log(isHorizontal);
        isUp = !isHorizontal && Mathf.Sign(direction.y) > 0.0f;
        isDown = !isHorizontal && Mathf.Sign(direction.y) < 0.0f;

        animator.SetBool("IsHorizontal", isHorizontal);
        animator.SetBool("IsUp", isUp);
        animator.SetBool("IsDown", isDown);

        // ???
        this.light.intensity = playerControler.currentHP / 20;
	}
}
