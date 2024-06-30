/*
* Author:  Sung Yeji
* Date: 20/06/2024
* Description: This script is for the dialogues
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

/// <summary>
/// Manages a dialogue box that displays text lines one by one with typewriter effect.
/// </summary>
public class DialogueBox : MonoBehaviour
{
    /// <summary>
    /// The GameObject containing the dialogue box UI.
    /// </summary>
    [SerializeField] GameObject dialogueBox;

    /// <summary>
    /// The TextMeshProUGUI component used to display the dialogue text.
    /// </summary>
    public TextMeshProUGUI textComponent;

    /// <summary>
    /// Array of dialogue lines to display.
    /// </summary>
    public string[] lines;

    /// <summary>
    /// Speed at which each character of the dialogue lines is typed out.
    /// </summary>
    public float textSpeed;

    /// <summary>
    /// Index of the current dialogue line.
    /// </summary>
    private int index;

    /// <summary>
    /// Start is called before the first frame update. Initializes the dialogue box and starts the dialogue.
    /// </summary>
    void Start()
    {
        textComponent.text = string.Empty;
        dialogueBox.SetActive(true);
        StartDialogue();
    }

    /// <summary>
    /// Update is called once per frame. Checks for input to progress to the next dialogue line.
    /// </summary>
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

    /// <summary>
    /// Starts displaying the dialogue from the beginning.
    /// </summary>
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    /// <summary>
    /// Coroutine that types out each character of the current dialogue line.
    /// </summary>
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    /// <summary>
    /// Moves to the next dialogue line or hides the dialogue box if all lines are displayed.
    /// </summary>
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            textComponent.text = null;
            gameObject.SetActive(false);
        }
    }
}
