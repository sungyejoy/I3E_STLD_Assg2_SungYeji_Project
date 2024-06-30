/*
* Author: Sung Yeji
* Date: 30/06/2024
* Description: Script for Teleportation (Child script) 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Teleportation : Interactable
{
    /// <summary>
    /// The audio clip that plays when the medicine is collected.
    /// </summary>
    [SerializeField] private AudioClip teleportation_sound;

    /// <summary>
    /// An override code of the View function
    /// </summary>
    public override void View()
    {
        // Play the bonus sound at the teleport's position
        AudioSource.PlayClipAtPoint(teleportation_sound, transform.position, 1f);

        base.View();
        GameManager.Instance.warning_text.text = ("Press E to Interact");

    }
}
