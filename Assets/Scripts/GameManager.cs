using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
