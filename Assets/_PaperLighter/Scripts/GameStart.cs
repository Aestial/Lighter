using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Rewired;

public class GameStart : MonoBehaviour
{
    public Rewired.Player rp { get { return ReInput.isReady ? ReInput.players.GetPlayer(0) : null; } }

    private void Update()
    {
        if (!ReInput.isReady) return;
        if (rp.GetButtonDown("Fire"))
        {
            // Do Shit
            SceneManager.LoadScene("Main");

        }
    }
}
