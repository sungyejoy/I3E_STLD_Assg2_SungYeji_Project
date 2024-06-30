/*
* Author: Sung Yeji
* Date: 22/06/2024
* Description: Script for when picking up the gun (Child script) 
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;

public class start_gun : Interactable
{
    /// <summary>
    /// Stating the UI elements
    /// </summary>
    [SerializeField] GameObject gun;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gun_camera;

    public door linkedDoor;

    public bool gun_pickup = false;

    [SerializeField] private AudioClip bonus_sound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Collectible(player player)
    {
        // Update the player on the current collectible
        player.gameObject.GetComponent<player>().UpdateCollectible(this);

        AudioSource.PlayClipAtPoint(bonus_sound, transform.position, 1f);

        // Turn off warning UI
        GameManager.Instance.warning_img.SetActive(false);

        // Tell the door to unlock itself
        linkedDoor.SetLock(false);

        // Change boolean to true when key is picked up
        GameManager.Instance.gun_pickup = true;
        player.gameObject.GetComponent<player>().gunBoolean(GameManager.Instance.gun_pickup);

        gun_camera.SetActive(true);

        base.Collectible(player);
    }
}
