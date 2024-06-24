/*
* Author: Sung Yeji
* Date: 24/06/2024
* Description: Script for Door 
*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] public GameObject warning_img;
    public TextMeshProUGUI warning_text;

    public string text = "Press E to Interact";

    public Animator transition;

    public float transitionTime = 1f;

    public virtual void Collectible()
    {
        Destroy(gameObject);
    }

    public virtual void View()
    {
        // Turn on warningUI when the player enters trigger
        warning_img.SetActive(true);

    }

    public virtual void ChangeScene()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)
            );
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        /// <summary>
        /// Pauses the transition for x seconds
        /// </summary>
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        // Wait

        // Load scene
    }


    // Start is called before the first frame update
    void Start()
    {
        warning_text.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
