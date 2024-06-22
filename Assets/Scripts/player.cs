/*
* Author:  Sung Yeji
* Date: 21/06/2024
* Description: This script is for the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine.ProBuilder.Shapes;

public class player : MonoBehaviour
{
    public int playerHealth = 100;
    public TextMeshProUGUI playerHealthText;

    [SerializeField] GameObject heart;

    /// <summary>
    /// Store the current door in front of the player
    /// </summary>
    door currentDoor;

    start_gun currentGun;
    public bool gun_pickup = false;

    // Start is called before the first frame update
    void Start()
    {
        /// <summary>
        /// Turn on UI
        /// </summary>
        playerHealthText.text = "Health: " + playerHealth;
        heart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Connects object that has HoneypotKey script
    public void UpdateCollectible(start_gun newCollectible)
    {
        currentGun = newCollectible;
    }

    // Reference to see if the honeypot key was picked up or not
    public void gunBoolean(bool reference)
    {
        gun_pickup = reference;
    }

    // When an interaction happens
    void OnInteract()
    {
        // This is a "null check" for the door
        if (currentDoor != null)
        {
            Debug.Log("currentdoor null");
            currentDoor.OpenDoor();
            currentDoor = null;
        }

        // Do a null check for the currentCollectible (honeypotkey)
        if (currentGun != null)
        {
            Debug.Log("currentgun null");
            currentGun.Collected();
            currentGun = null;
        }
    }

        public void UpdateDoor(door newDoor)
    {
        currentDoor = newDoor;
    }
}
