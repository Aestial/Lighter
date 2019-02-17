using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class JoystickDetect : MonoBehaviour
{
    [SerializeField] GameObject joystickIndicator;
    bool hasJoysticks;
    bool firstTime = true;

    void Update()
    {
        if(!ReInput.isReady) return;
        if (firstTime)
        {
            StartCoroutine(CheckJoysticks());
            firstTime = false;
        }
    }

    IEnumerator CheckJoysticks()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        hasJoysticks = ReInput.controllers.joystickCount > 0;
        joystickIndicator.SetActive(hasJoysticks);

        Debug.Log(ReInput.controllers.joystickCount);
        Debug.Log(hasJoysticks);
    }
}
