using UnityEngine;

public class BreakableTile : MonoBehaviour, IBreakable, IDamageable<int>
{
    [SerializeField] int steps = 1;
    private int currentSteps;

    public void Break()
    {
        Destroy(this.gameObject);
    }

    public void Damage(int damageTaken)
    {
        currentSteps -= damageTaken;
        if (currentSteps <= 0)
        {
            Break();
        }
    }
    
    //void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Triggered on a Breakable Tile");
    //}
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collided on a Breakable Tile");
        Damage(1);
    }
    void Start()
    {
        currentSteps = steps;
    }
}
