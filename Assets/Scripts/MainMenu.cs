/*
* Author: Sung Yeji
* Date: 24/06/2024
* Description: Script for the Main Menu UI items 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script handles the main menu functionalities such as changing scenes and quitting the game.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// The index of the target scene to load.
    /// </summary>
    public int targetSceneIndex;

    /// <summary>
    /// Changes the current scene to the target scene specified by the targetSceneIndex.
    /// </summary>
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }

    /// <summary>
    /// Logs a message to the console when a button is clicked.
    /// </summary>
    public void ClickFunction()
    {
        Debug.Log("Button was clicked");
    }

    /// <summary>
    /// Quits the application and logs a quit message to the console.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}