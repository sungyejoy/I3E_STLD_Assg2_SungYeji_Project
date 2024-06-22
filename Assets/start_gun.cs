/*
* Author: Sung Yeji
* Date: 22/06/2024
* Description: Script for when picking up the gun
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class start_gun : MonoBehaviour
{
    /// <summary>
    /// Stating the UI elements
    /// </summary>
    [SerializeField] GameObject gun;
    [SerializeField] GameObject warning_img;
    [SerializeField] GameObject approval_img;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gun_camera;

    public TextMeshProUGUI warning_text;

    public door linkedDoor;

    bool gun_pickup = false;

    [SerializeField] private AudioClip bonus_sound;


    // Start is called before the first frame update
    void Start()
    {
        warning_text.text = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Update the player on the current collectible
            player.gameObject.GetComponent<player>().UpdateCollectible(this);

            // Turn on warningUI when the player enters trigger
            warning_img.SetActive(true);

            // Turn on notificationText 
            warning_text.text = ("Press E to pick up");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object entering the trigger has "Player"
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().UpdateCollectible(null);

            // Turn off UI
            warning_img.SetActive(false);
            warning_text.text = null;
        }

        if (other.gameObject.GetComponent<player>().gun_pickup == true)
        {
            // Turn off all UI and destroy game object once exiting trigger
            warning_img.SetActive(false);
            approval_img.SetActive(false);
            Destroy(gameObject);
        }

    }

    public void Collected()
    {
        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        // Turn off warning UI
        warning_img.SetActive(false);

        // Turn on approvalUI when the player picks up the key
        approval_img.SetActive(true);

        // Turn on notificationText 
        warning_text.text = ("You found the Unlimited Ammo Neon Gun!");

        // Tell the door to unlock itself
        linkedDoor.SetLock(false);

        // Destroy the gameObject
        Destroy(gun);

        // Change boolean to true when key is picked up
        gun_pickup = true;
        player.gameObject.GetComponent<player>().gunBoolean(gun_pickup);

        gun_camera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
