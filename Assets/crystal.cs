/*
* Author:  Sung Yeji
* Date: 29/06/2024
* Description: This script is for the Crystal (Special) Collectible that can be carried across scenes, and placed down
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Class for the Crystal collectible that can be carried across scenes.
/// </summary>
public class crystal : Interactable
{
    /// <summary>
    /// Sound effect of picking up the crystal.
    /// </summary>
    [SerializeField] private AudioClip bonus_sound;

    /// <summary>
    /// Gun connected to the first person camera.
    /// </summary>
    [SerializeField] GameObject gun;

    /// <summary>
    /// Crystal connected to the first person camera.
    /// </summary>
    [SerializeField] GameObject crystal_obj;

    /// <summary>
    /// Teleportation Object to pop up when the crystal is collected.
    /// </summary>
    [SerializeField] GameObject teleport;

    /// <summary>
    /// Start is called before the first frame update. Leaves the crystal on the first person camera and teleport inactive at first.
    /// </summary>
    void Start()
    {
        crystal_obj.SetActive(false);
        teleport.SetActive(false);
    }

    /// <summary>
    /// An override of the Collectible function. Handles the interaction logic for collecting the crystal.
    /// </summary>
    public override void Collectible(player player)
    {
        // Set the crystal on first person camera to be active when player interacts with the crystal object
        crystal_obj.SetActive(true);

        // Set the gun on the first person camera to be inactive when the crystal object is interacted with
        gun.SetActive(false);

        // Update the player on the current collectible
        player.gameObject.GetComponent<player>().UpdateCrystal(this);

        // Play the bonus sound
        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        // Turn off warning UI
        GameManager.Instance.warning_img.SetActive(false);

        // Change boolean to true when the crystal is picked up
        GameManager.Instance.crystal_pickup = true;
        player.gameObject.GetComponent<player>().crystalBoolean(GameManager.Instance.crystal_pickup);

        // Run Destroy GameObject code
        base.Collectible(player);

        // Set the teleportation object to active
        teleport.SetActive(true);
    }
}
