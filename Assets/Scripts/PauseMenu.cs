/*
* Author:  Sung Yeji
* Date: 21/06/2024
* Description: This script is for the Pause Menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the pause menu and game state related to pausing and resuming the game.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Indicates whether the game is currently paused.
    /// </summary>
    public static bool GameIsPaused = false;

    /// <summary>
    /// The UI element representing the pause menu.
    /// </summary>
    public GameObject pauseMenuUI;

    /// <summary>
    /// The index of the target scene to load when returning to the menu.
    /// </summary>
    public int targetSceneIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Logs a message indicating a button was clicked.
    /// </summary>
    public void ClickFunction()
    {
        Debug.Log("Button was clicked");
    }

    /// <summary>
    /// Resumes the game from the paused state.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /// <summary>
    /// Loads the menu scene specified by the target scene index.
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }

    /// <summary>
    /// Quits the game and logs a message.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
