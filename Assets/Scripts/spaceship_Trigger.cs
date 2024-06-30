/*
* Author:  Sung Yeji
* Date: 30/06/2024
* Description: This script is for the spaceship trigger
*/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for the Water Boy trigger that handles dialogue interactions.
/// </summary>
public class spaceship_Trigger : MonoBehaviour
{
    /// <summary>
    /// warning Img
    /// </summary>
    [SerializeField] GameObject warning_img;

    /// <summary>
    /// Warning text
    /// </summary>
    public TextMeshProUGUI warning_text;

    /// <summary>
    /// Duration of transition animation when changing scenes.
    /// </summary>
    public float transitionTime = 1f;

    /// <summary>
    /// The player's crystal in the final_waterboy script
    /// </summary>
    public final_waterboy final_waterboy;

    /// <summary>
    /// Start is called before the first frame update. Sets the speech bubble to active and initializes the dialogue box.
    /// </summary>

    void Start()
    {
        warning_img.SetActive(false);
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to the object this script is attached to.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("entered");
            Debug.Log(final_waterboy.crystal_drop);

            if (final_waterboy.crystal_drop == false)
            {
                warning_img.SetActive(true);
                warning_text.text = "Pass the crystal!";
            }


            if (final_waterboy.crystal_drop == true)
            {
                warning_img.SetActive(false);
                warning_text.text = null;
                ChangeScene();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PLayer")
        {
            warning_img.SetActive(false);
            warning_text.text = null;
        }
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
}
