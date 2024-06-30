using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject warning_img;

    public TextMeshProUGUI warning_text;

    public GameObject dialogueBox;
    public TextMeshProUGUI textComponent;

    public Animator transition;

    public GameObject hurt;

    public AudioSource hurt_audio;

    public float maxHealth = 100;
    public float currentHealth;

    public int currentEnemy = 0;

    public TextMeshProUGUI currentEnemyText;

    public bool gun_pickup;

    public bool crystal_pickup = false;

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
        stopwatchText.text = "Time: 0:00";
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
