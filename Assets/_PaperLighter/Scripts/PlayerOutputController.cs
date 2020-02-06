using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutputController : MonoBehaviour 
{
    [SerializeField] float startSpeedThreshold;
    [SerializeField] float speedMultiplier = 1.0f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Transform flare;
    [SerializeField] float maxFlare;
    [SerializeField] float minFlare;

    PlayerController playerController;

    private float speed;
    private Vector2 direction;
    private bool isHorizontal;
    private bool isUp;
    private bool isDown;
    private bool isLeft;

    float currentHP;

	// Use this for initialization
	void Start () 
    {
        playerController = GetComponent<PlayerController>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentHP = playerController.currentHP;
        speed = playerController.speed * speedMultiplier;
        direction = playerController.direction;

        float flareScale = Mathf.Lerp(minFlare, maxFlare, currentHP);
        flare.localScale = new Vector3(flareScale, flareScale, flareScale);

        if (speed > startSpeedThreshold)
        {
            animator.SetBool("IsIdle", false);
            animator.SetFloat("Speed", speed);
            
            isHorizontal = Mathf.Abs(direction.x) > Mathf.Abs(direction.y);
            isUp = !isHorizontal && Mathf.Sign(direction.y) > 0.0f;
            isDown = !isHorizontal && Mathf.Sign(direction.y) < 0.0f;
            isLeft = isHorizontal && Mathf.Sign(direction.x) < 0.0f;

            animator.SetBool("IsHorizontal", isHorizontal);
            animator.SetBool("IsUp", isUp);
            animator.SetBool("IsDown", isDown);

            this.spriteRenderer.flipX = isLeft;
        }
        else 
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsUp", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsHorizontal", false);
        }
        
	}
}
