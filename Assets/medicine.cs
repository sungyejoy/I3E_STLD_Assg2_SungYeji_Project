/*
* Author: Sung Yeji
* Date: 28/06/2024
* Description: Script for Medicine Pill
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Represents a medicine object that can be collected by the player to increase health.
/// </summary>
public class medicine : Interactable
{
    /// <summary>
    /// The game object representing the medicine pill.
    /// </summary>
    [SerializeField] GameObject medicine_pill;

    /// <summary>
    /// The player game object.
    /// </summary>
    [SerializeField] GameObject player;

    /// <summary>
    /// The audio clip that plays when the medicine is collected.
    /// </summary>
    [SerializeField] private AudioClip bonus_sound;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code here, if needed
    }

    /// <summary>
    /// Collects the medicine and increases the player's health.
    /// </summary>
    public override void Collectible(player player)
    {
        // Play the bonus sound at the medicine's position
        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        // Increase the player's health if it's 100 or less
        if (GameManager.Instance.currentHealth <= 100)
        {
            GameManager.Instance.currentHealth += 30f;
        }

        // Turn off the warning UI
        GameManager.Instance.warning_img.SetActive(false);

        // Call the base class's Collectible method to handle standard collection behavior
        base.Collectible(player);
    }

}
