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
public class DeathUI : MonoBehaviour
{
    /// <summary>
    /// The UI element representing the pause menu.
    /// </summary>
    public GameObject deathMenuUI;

    /// <summary>
    /// The index of the target scene to load when returning to the menu.
    /// </summary>
    public int targetSceneIndex;

    /// <summary>
    /// Logs a message indicating a button was clicked.
    /// </summary>
    public void ClickFunction()
    {
        Debug.Log("Button was clicked");
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
