/*
* Author:  Sung Yeji
* Date: 22/06/2024
* Description: This script is for the Water Boy trigger
*/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class for the Water Boy trigger that handles dialogue interactions.
/// </summary>
public class waterBoy_trigger : MonoBehaviour
{
    /// <summary>
    /// GameObject of the speech bubble.
    /// </summary>
    [SerializeField] GameObject speech;

    /// <summary>
    /// AudioClip of WaterBoy talking.
    /// </summary>
    [SerializeField] private AudioClip talking;

    /// <summary>
    /// Lines of the dialogues.
    /// </summary>
    public string[] lines;

    /// <summary>
    /// Speed of the text being typed out.
    /// </summary>
    public float textSpeed;

    /// <summary>
    /// Index of the dialogue line.
    /// </summary>
    private int index;

    /// <summary>
    /// Start is called before the first frame update. Sets the speech bubble to active and initializes the dialogue box.
    /// </summary>
    void Start()
    {
        speech.SetActive(true);
        GameManager.Instance.dialogueBox.SetActive(false);
        GameManager.Instance.textComponent.text = string.Empty;
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to the object this script is attached to.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("enter");
            speech.SetActive(false);
            GameManager.Instance.dialogueBox.SetActive(true);
            GameManager.Instance.textComponent.text = string.Empty;
            StartDialogue();
        }
    }

    /// <summary>
    /// Update is called once per frame. Handles mouse button input for progressing the dialogue.
    /// </summary>
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

    /// <summary>
    /// Starts the dialogue by initializing the index and starting the coroutine to type out the first line.
    /// </summary>
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        //AudioSource.PlayClipAtPoint(talking, transform.position, 1f);
    }

    /// <summary>
    /// Coroutine to type out a line of dialogue character by character.
    /// </summary>
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            GameManager.Instance.textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    /// <summary>
    /// Advances to the next line of dialogue or ends the dialogue if there are no more lines.
    /// </summary>
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            GameManager.Instance.textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            GameManager.Instance.dialogueBox.SetActive(false);
            GameManager.Instance.textComponent.text = null;
            //AudioSource.Destroy(talking);
            gameObject.SetActive(false);
        }
    }
}
