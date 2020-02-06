using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    [SerializeField] float totalTime;
    public float currentTime;
    [SerializeField] Text timeText;
    [SerializeField] Light ambientLight;

    public FlameBehaviour[] lights;

    private int counter;

	// Use this for initialization
	void Start () 
    {
        this.currentTime = this.totalTime;
        this.lights = FindObjectsOfType<FlameBehaviour>();
        Debug.Log("Number of lights: " + this.lights.Length);
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckTime();
        CheckLights();
	}

    void CheckLights()
    {
        int count = lights.Length;

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].actualHP <= 0.0f)
            {
                count--;
            }
        }
        if (count <= 0)
        {
            // GAME OVER
            Debug.Log("GameManager: GAME OVER");
            SceneManager.LoadScene("GameOver");
        }

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].actualHP > 0.0f)
            {
                lights[i].drainMultiplier = (lights.Length / 1.3f) / count;
            }
        }
        ambientLight.intensity = count / lights.Length;
    }

    void CheckTime ()
    {
        this.currentTime -= Time.deltaTime;
        this.timeText.text = "TIME: " + this.currentTime;
        if (this.currentTime <= 0.0f)
        {
            // YOU WIN
            Debug.Log("GameManager: YOU WIN");
            SceneManager.LoadScene("Win");
        }
    }
}
