/*
* Author:  Sung Yeji
* Date: 24/06/2024
* Description: This script is for the Game Manager Script
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

/// <summary>
/// Manages the game state and global game properties.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the GameManager.
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// UI element for the warning image.
    /// </summary>
    public GameObject warning_img;

    /// <summary>
    /// Text component for displaying warnings.
    /// </summary>
    public TextMeshProUGUI warning_text;

    /// <summary>
    /// UI element for the dialogue box.
    /// </summary>
    public GameObject dialogueBox;

    /// <summary>
    /// Text component for displaying dialogue.
    /// </summary>
    public TextMeshProUGUI textComponent;

    /// <summary>
    /// Animator component for scene transitions.
    /// </summary>
    public Animator transition;

    /// <summary>
    /// UI element for indicating player hurt.
    /// </summary>
    public GameObject hurt;

    /// <summary>
    /// Audio source for playing hurt sounds.
    /// </summary>
    public AudioSource hurt_audio;

    /// <summary>
    /// The maximum health of the player.
    /// </summary>
    public float maxHealth = 100;

    /// <summary>
    /// The current health of the player.
    /// </summary>
    public float currentHealth;

    /// <summary>
    /// The current number of enemies defeated.
    /// </summary>
    public int currentEnemy = 0;

    /// <summary>
    /// Text component for displaying the current enemy count.
    /// </summary>
    public TextMeshProUGUI currentEnemyText;

    /// <summary>
    /// Indicates whether the player has picked up a gun.
    /// </summary>
    public bool gun_pickup;

    /// <summary>
    /// Indicates whether the player has picked up a crystal.
    /// </summary>
    public bool crystal_pickup = false;

    /// <summary>
    /// Indicates whether the stopwatch is running.
    /// </summary>
    public bool stopwatch;

    /// <summary>
    /// The current time of the stopwatch.
    /// </summary>
    public float currentTime;

    /// <summary>
    /// Text component for displaying the stopwatch time.
    /// </summary>
    public TextMeshProUGUI stopwatchText;

    /// <summary>
    /// UI element for the stopwatch image.
    /// </summary>
    [SerializeField] GameObject stopwatchImg;

    /// <summary>
    /// Player capsule object
    /// </summary>
    [SerializeField] public GameObject playerCapsule;

    /// <summary>
    /// Gun on camera
    /// </summary>
    [SerializeField] public GameObject gun_cam;

    /// <summary>
    /// Crystal on camera
    /// </summary>
    [SerializeField] public GameObject crystal_cam;

    /// <summary>
    /// Death UI
    /// </summary>
    [SerializeField] public GameObject deathUI;

    /// <summary>
    /// Pause UI
    /// </summary>
    [SerializeField] public GameObject pauseUI;

    /// <summary>
    /// String to display minutes.
    /// </summary>
    public string min = "";

    /// <summary>
    /// String to display seconds.
    /// </summary>
    public string sec = "";

    /// <summary>
    /// Initializes the GameManager instance and sets up the stopwatch.
    /// </summary>
    void Start()
    {
        // Set everything to 0 and turn on stopwatch UI
        currentTime = 0;
        stopwatchImg.SetActive(true);
        stopwatchText.text = "Time: 0:00";
    }

    /// <summary>
    /// Updates the stopwatch time each frame.
    /// </summary>
    void Update()
    {
        if (stopwatch)
        {
            // Add time to our stopwatch while remaining completely independent from CPU performance
            currentTime += Time.deltaTime;

            // Allow us to easily store our time in seconds, minutes, hours. etc.
            TimeSpan time = TimeSpan.FromSeconds(currentTime);

            // Save the minutes and seconds into the string variables
            min = time.Minutes.ToString();
            sec = time.Seconds.ToString();

            // Convert the stopwatch timing into minutes and seconds
            stopwatchText.text = "Time: " + time.Minutes + ":" + time.Seconds;
        }
    }


    /// <summary>
    /// Ensures that only one instance of the GameManager exists and persists across scenes.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
