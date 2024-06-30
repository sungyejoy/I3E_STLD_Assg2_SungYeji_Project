/*
* Author:  Sung Yeji
* Date: 24/06/2024
* Description: This script is for the door in spaceship to add a transition when changing scenes
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script handles the door transition, playing an animation and loading the next level when certain conditions are met.
/// </summary>
public class doorTransition : MonoBehaviour
{
    /// <summary>
    /// The Animator component that handles the transition animations.
    /// </summary>
    public Animator transition;

    /// <summary>
    /// The duration of the transition animation.
    /// </summary>
    public float transitionTime = 1f;

    /// <summary>
    /// The UI Text component to display notifications.
    /// </summary>
    public TextMeshProUGUI notificationText;

    /// <summary>
    /// The UI Image indicating approval for loading the next level.
    /// </summary>
    [SerializeField] GameObject approval_img;

    /// <summary>
    /// Update is called once per frame. Currently empty.
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Called when another collider collides with the trigger collider attached to the object this script is attached to.
    /// If the player has picked up the gun, displays a notification and loads the next level.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Instance.gun_pickup == true)
        {
            approval_img.SetActive(true);
            notificationText.text = "Loading Level 1...";
            LoadNextLevel();
        }
    }

    /// <summary>
    /// Starts the coroutine to load the next level.
    /// </summary>
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    /// <summary>
    /// Coroutine to handle the level loading process with an animation transition.
    /// </summary>
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        // Pause the transition for the specified time
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }
}