using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class NextScene : MonoBehaviour {

    [SerializeField] string nextSceneName;

    public Rewired.Player rp { get { return ReInput.isReady ? ReInput.players.GetPlayer(0) : null; } }

    private void Update()
    {
        if (!ReInput.isReady) return;
        if (rp.GetButtonDown("Fire"))
        {
            // Do Shit
            SceneManager.LoadScene(nextSceneName);

        }

    }

}
