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

    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject speech;
    public TextMeshProUGUI textComponent;

    public string[] lines;
    public float textSpeed;

    private int index;

    public virtual void Collectible()
    {
        Destroy(gameObject);
    }

    public virtual void View()
    {
        // Turn on warningUI when the player enters trigger
        warning_img.SetActive(true);

    }

    public virtual void Dialogue()
    {
        speech.SetActive(false);
        dialogueBox.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            Debug.Log(lines.Length);
            Debug.Log(index);
        }

        else
        {
            Debug.Log("hi");
            dialogueBox.SetActive(false);
            textComponent.text = null;
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

        dialogueBox.SetActive(false);
        speech.SetActive(true);
        textComponent.text = string.Empty;
    }

}
