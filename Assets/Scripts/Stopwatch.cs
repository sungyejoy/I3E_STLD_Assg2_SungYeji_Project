/*
* Author: Sung Yeji
* Date: 25/06/2024
* Description: Script for Stopwatch 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This script is for a Stopwatch that will time the player's duration of the game played.
/// </summary>
public class Stopwatch : MonoBehaviour
{
    /// <summary>
    /// Indicates if the stopwatch is running.
    /// </summary>
    public bool stopwatch;

    /// <summary>
    /// Stores the current time of the stopwatch.
    /// </summary>
    public float currentTime;

    /// <summary>
    /// UI element to display the stopwatch time.
    /// </summary>
    public TextMeshProUGUI stopwatchText;

    /// <summary>
    /// Image representing the stopwatch UI.
    /// </summary>
    [SerializeField] GameObject stopwatchImg;

    /// <summary>
    /// String to store minutes.
    /// </summary>
    public string min = "";

    /// <summary>
    /// String to store seconds.
    /// </summary>
    public string sec = "";

    /// <summary>
    /// Start is called before the first frame update. Initializes the stopwatch.
    /// </summary>
    void Start()
    {
        currentTime = 0;
        stopwatchImg.SetActive(true);
        stopwatchText.text = "Time: 0:00";
    }

    /// <summary>
    /// Update is called once per frame. Updates the stopwatch time if it is running.
    /// </summary>
    void Update()
    {
        if (stopwatch == true)
        {
            // Add time to the stopwatch while remaining completely independent from CPU performance
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
}
