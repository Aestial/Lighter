using UnityEngine;

public class FollowTarget : MonoBehaviour 
{    
    [SerializeField] Transform target;
    [SerializeField] float startDistanceThreshold;
    [SerializeField] float stopDistanceThreshold;
    [SerializeField] float startSpeed;
    [SerializeField] float stopSpeed;
    [SerializeField] float speed = 2.0f;
    private Vector3 offset;
    private bool isMoving;

    void Start()
    {
        offset = transform.position;
    }
    void Update ()
    {
        Vector3 noOffsetPos = transform.position - offset;
        float distance = Vector3.Distance(noOffsetPos, target.position);

        if (!isMoving 
            && (target.GetComponent<Rigidbody>().velocity.magnitude >= startSpeed)
            && (distance >= startDistanceThreshold))
        {
            isMoving = true;    
        }
        if (isMoving)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 finalPosition = target.position + offset;

            Vector3 position = transform.position;
            position.x = Mathf.Lerp(transform.position.x, finalPosition.x, interpolation);
            position.y = Mathf.Lerp(transform.position.y, finalPosition.y, interpolation);
            position.z = Mathf.Lerp(transform.position.z, finalPosition.z, interpolation);

            transform.position = position;    
        }
        if (isMoving 
            && (target.GetComponent<Rigidbody>().velocity.magnitude <= stopSpeed)
            && (distance <= stopDistanceThreshold))
        {
            isMoving = false;
        }
	}
}
