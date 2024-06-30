/*
* Author:  Sung Yeji
* Date: 28/06/2024
* Description: This script is for the Jump Increase Pill (Child Script)
*/

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling the interaction that increases the player's jump height.
/// </summary>
public class JumpIncrease : Interactable
{
    /// <summary>
    /// The amount by which the jump height will be increased.
    /// </summary>
    float increaseJumpHeight = 6.0f;

    /// <summary>
    /// The audio clip that plays when the medicine is collected.
    /// </summary>
    [SerializeField] private AudioClip bonus_sound;

    /// <summary>
    /// Overrides the Collectible method to increase the player's jump height.
    /// </summary>
    public override void Collectible(player player)
    {
        // Play the bonus sound at the pill's position
        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        player.GetComponent<FirstPersonController>().JumpHeight += increaseJumpHeight;
        base.Collectible(player);
    }
}
