using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowTarget : MonoBehaviour 
{
	[SerializeField] Transform target;
    [SerializeField] float startDistanceThreshold;
    [SerializeField] float stopDistanceThreshold;
    [SerializeField] float startSpeed;
    [SerializeField] float stopSpeed;
    [SerializeField] Vector3 offset;

    [SerializeField] float speed = 2.0f;

    public bool isMoving = false;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(this.transform.position, target.position);

        if (!this.isMoving 
            && (target.GetComponent<Rigidbody>().velocity.magnitude >= this.startSpeed)
            && (distance >= (this.startDistanceThreshold + this.offset.magnitude)))
        {
            this.isMoving = true;    
        }

        if (this.isMoving)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 finalPosition = target.position + offset;

            Vector3 position = this.transform.position;
            position.x = Mathf.Lerp(this.transform.position.x, finalPosition.x, interpolation);
            position.y = Mathf.Lerp(this.transform.position.y, finalPosition.y, interpolation);
            position.z = Mathf.Lerp(this.transform.position.z, finalPosition.z, interpolation);

            this.transform.position = position;    
        }

        if (this.isMoving 
            && (target.GetComponent<Rigidbody>().velocity.magnitude <= this.stopSpeed)
            && (distance <= (this.stopDistanceThreshold + this.offset.magnitude)))
        {
            this.isMoving = false;
        }
	}
}
