using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    // State the UI elements
    public bool stopwatch;
    public float currentTime;
    public TextMeshProUGUI stopwatchText;
    [SerializeField] GameObject stopwatchImg;
    public string min = "";
    public string sec = "";

    // Start is called before the first frame update
    void Start()
    {
        // Set everything to 0 and turn on stopwatch UI
        currentTime = 0;
        stopwatchImg.SetActive(true);
        stopwatchText.text = "0:00";
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch == true)
        {
            // Add time to our stopwatch while remaining completely independent from CPU performance
            currentTime = currentTime + Time.deltaTime;

            // Allow us to easily store our time in seconds, minutes, hours. etc.
            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            // Save the minutes and seconds into the string variables
            min = time.Minutes.ToString();
            sec = time.Seconds.ToString();

            // Convert the stopwatch timing into minutes and seconds
            stopwatchText.text = "Time: " + time.Minutes.ToString() + ":" + time.Seconds.ToString();

        }
    }

    /// This script is for a Stopwatch that will time the player's duration of the game played ///
}
