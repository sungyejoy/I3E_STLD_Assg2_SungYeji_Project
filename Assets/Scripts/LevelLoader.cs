/*
* Author:  Sung Yeji
* Date: 21/06/2024
* Description: This script is for the Level Loader
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles level loading with a transition animation.
/// </summary>
public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// The animator component for handling transitions.
    /// </summary>
    public Animator transition;

    /// <summary>
    /// The time to wait during the transition.
    /// </summary>
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    /// <summary>
    /// Starts loading the next level.
    /// </summary>
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    /// <summary>
    /// Loads the level with the specified index after a transition.
    /// </summary>
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play the transition animation
        transition.SetTrigger("Start");

        // Pause the transition for a specified time
        yield return new WaitForSeconds(transitionTime);

        // Load the specified scene
        SceneManager.LoadScene(levelIndex);
    }
}