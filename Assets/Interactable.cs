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

    [SerializeField] GameObject speech;

    public string[] lines;
    public float textSpeed;

    private int index;
    private int max_index;

    public virtual void Collectible()
    {
        Destroy(gameObject);
    }

    public virtual void View()
    {
        // Turn on warningUI when the player enters trigger
        GameManager.Instance.warning_img.SetActive(true);

    }

    public virtual void Dialogue()
    {
        speech.SetActive(false);
        GameManager.Instance.dialogueBox.SetActive(true);
        GameManager.Instance.textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GameManager.Instance.textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                GameManager.Instance.textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            index = 0;
            max_index = 3;
        }
        
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            index = 4;
            max_index = 6;
        }
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        if (index <= max_index)
        {
            foreach (char c in lines[index].ToCharArray())
            {
                GameManager.Instance.textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            GameManager.Instance.textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            Debug.Log(lines.Length);
            Debug.Log(index);
        }

        else
        {
            Debug.Log("hi");
            GameManager.Instance.dialogueBox.SetActive(false);
            GameManager.Instance.textComponent.text = null;
            gameObject.SetActive(false);
        }
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
        speech.SetActive(true);
        GameManager.Instance.textComponent.text = string.Empty;
    }

}
