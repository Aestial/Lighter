using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("Title");
        }

    }

}
