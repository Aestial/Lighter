using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfActive : MonoBehaviour
{
    [SerializeField] bool setState;
    [SerializeField] float delay;

    void OnEnable()
    {
        StartCoroutine(DelayAndActive(setState, delay));
    }

    IEnumerator DelayAndActive(bool state, float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(state);
    }
}
