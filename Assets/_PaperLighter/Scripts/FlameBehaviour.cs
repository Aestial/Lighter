using System.Collections;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    [SerializeField] float cost = 0.25f;
    [SerializeField] float drainSpeed = 0.01f;
    [SerializeField] float debounceTime = 1.0f;
    [SerializeField] AudioClip fireSound;
    [SerializeField] float deadGoal = - 0.05f;
    public float deadThreshold = 0.05f;
    public float drainMultiplier = 1.0f;    
    public float actualHP;
    public float fixedtime = 0.01f;
    float maxHP = 1.0f;
    bool debounce;

    void Start()
    {
        actualHP = maxHP;
        StartCoroutine(Turnlight());
    }
    void OnTriggerEnter(Collider other)
    {
        if (!debounce && actualHP > deadThreshold && other.gameObject.name == "Player")
        {
            float playerHP = other.GetComponent<PlayerController>().currentHP;
            if (playerHP >= cost)
            {
                debounce = true;
                actualHP = maxHP;
                StopAllCoroutines();
                StartCoroutine(Turnlight());
                StartCoroutine(DebounceCoroutine());
                Debug.Log("Touching flame");
                other.GetComponent<PlayerController>().currentHP -= cost;
                AudioManager.Instance.PlayOneShoot2D(fireSound);
            }
        }
    }
    IEnumerator DebounceCoroutine()
    {
        yield return new WaitForSeconds(debounceTime);
        debounce = false;
    }
    IEnumerator Turnlight()
    {
        while (actualHP > deadGoal)
        {
            actualHP -= (drainSpeed * drainMultiplier);
            yield return new WaitForSeconds(fixedtime);
        }
    }
}
