using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("MainRicardo");
        }

    }

}
