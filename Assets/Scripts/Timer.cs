using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float startTime;

    private static float gameTime;
    public static float GameTime
    {
        get { return gameTime; }
        set { gameTime = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = Time.time - startTime;

        string minutes = ((int)gameTime / 60).ToString();
        string seconds = (gameTime % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds; 
    }
}
