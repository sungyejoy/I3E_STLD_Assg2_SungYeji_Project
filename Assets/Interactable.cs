/*
* Author: Sung Yeji
* Date: 24/06/2024
* Description: Script for Interactions (Parent script) 
*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Base class for interactable objects in the game.
/// </summary>
public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Default text to display when interacting with the object.
    /// </summary>
    public string text = "Press E to Interact";

    /// <summary>
    /// Duration of transition animation when changing scenes.
    /// </summary>
    public float transitionTime = 1f;

    /// <summary>
    /// Virtual method to handle collecting the object.
    /// </summary>
    public virtual void Collectible(player player)
    {
        Destroy(gameObject); // Destroy the object when collected
    }

    /// <summary>
    /// Virtual method to handle viewing the object.
    /// </summary>
    public virtual void View()
    {
        // Turn on warningUI when the player enters trigger
        GameManager.Instance.warning_img.SetActive(true);
    }

    /// <summary>
    /// Virtual method to change the scene.
    /// </summary>
    public virtual void ChangeScene()
    {
        LoadNextLevel();
    }

    /// <summary>
    /// Coroutine to load the next level after a transition animation.
    /// </summary>
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    /// <summary>
    /// Coroutine to load a level with a transition animation.
    /// </summary>
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play transition animation
        GameManager.Instance.transition.SetTrigger("Start");

        // Pause the transition for the specified time
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(levelIndex);
    }

    /// <summary>
    /// Start is called before the first frame update. Initializes game objects and UI elements.
    /// </summary>
    void Start()
    {
        GameManager.Instance.warning_text.text = null; // Clear warning text

        GameManager.Instance.dialogueBox.SetActive(false); // Deactivate dialogue box
        GameManager.Instance.textComponent.text = string.Empty; // Clear text component
    }
}