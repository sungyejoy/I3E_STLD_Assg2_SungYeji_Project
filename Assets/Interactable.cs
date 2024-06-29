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

    public string text = "Press E to Interact";

    public float transitionTime = 1f;

    //[SerializeField] public GameObject speech;

    public virtual void Collectible(player player)
    {
        Destroy(gameObject);
    }

    public virtual void View()
    {
        // Turn on warningUI when the player enters trigger
        GameManager.Instance.warning_img.SetActive(true);

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
        GameManager.Instance.transition.SetTrigger("Start");

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
        GameManager.Instance.warning_text.text = null;

        GameManager.Instance.dialogueBox.SetActive(false);
        //speech.SetActive(true);
        GameManager.Instance.textComponent.text = string.Empty;
    }

}
