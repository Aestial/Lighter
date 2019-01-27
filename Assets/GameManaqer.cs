using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManaqer : MonoBehaviour 
{
    [SerializeField] float totalTime;
    public float currentTime;
    [SerializeField] Text timeText;

    public flameBehave[] lights;

	// Use this for initialization
	void Start () 
    {
        this.currentTime = this.totalTime;
        this.lights = GameObject.FindObjectsOfType<flameBehave>();
        Debug.Log("Number of lights: " + this.lights.Length);
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckTime();
        CheckLights(this.lights);
	}

    void CheckLights(flameBehave[] lights)
    {
        int count = 0;
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].actualHP <= 0.0f)
            {
                count++;
            }
        }
        if (count >= lights.Length)
        {
            // GAME OVER
            Debug.Log("GameManager: GAME OVER");
            //SceneManager.LoadScene("GameOver");
        }
    }

    void CheckTime ()
    {
        this.currentTime -= Time.deltaTime;
        this.timeText.text = "TIME: " + this.currentTime;
        if (this.currentTime <= 0.0f)
        {
            // YOU WIN
            Debug.Log("GameManager: YOU WIN");
            //SceneManager.LoadScene("Winner");
        }
    }
}
