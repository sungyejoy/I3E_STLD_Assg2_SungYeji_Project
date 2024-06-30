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

/// <summary>
/// Controls the player's interactions and behaviors.
/// </summary>
public class player : MonoBehaviour
{
    /// <summary>
    /// Stores the current door in front of the player.
    /// </summary>
    door currentDoor;
    Interactable collectible;

    start_gun currentGun;

    crystal crystal;

    /// <summary>
    /// The main camera of the player.
    /// </summary>
    [SerializeField] Transform main_camera;

    /// <summary>
    /// The maximum distance the player can interact with objects.
    /// </summary>
    [SerializeField] float interactionDistance;

    /// <summary>
    /// The level 1 teleporter GameObject.
    /// </summary>
    [SerializeField] GameObject level1_teleporter;

    /// <summary>
    /// The maximum interaction distance.
    /// </summary>
    int max_distance = 5;

    /// <summary>
    /// Determines if the player is shooting.
    /// </summary>
    bool gun_shoot = false;

    /// <summary>
    /// The player's gun.
    /// </summary>
    public Gun gun;

    /// <summary>
    /// The player's crystal in the final_waterboy script
    /// </summary>
    public final_waterboy final_waterboy;

    /// <summary>
    /// Initializes the player's UI elements.
    /// </summary>
    void Start()
    {
        GameManager.Instance.currentEnemyText.text = "Enemies: " + GameManager.Instance.currentEnemy + "/20";
    }

    /// <summary>
    /// Updates the player's state each frame.
    /// </summary>
    void Update()
    {
        Debug.DrawLine(main_camera.position, main_camera.position + (main_camera.forward * interactionDistance), Color.red);

        RaycastHit hit;

        if (Physics.Raycast(main_camera.transform.position, main_camera.transform.forward, out hit, max_distance))
        {
            if (hit.transform.TryGetComponent<Interactable>(out collectible))
            {
                if (hit.transform.tag == "Collectible")
                {
                    GameManager.Instance.warning_img.SetActive(true);
                    GameManager.Instance.warning_text.text = collectible.text.ToString();
                }
                else if (hit.transform.tag == "Door")
                {
                    collectible.View();
                }
            }
            else
            {
                GameManager.Instance.warning_img.SetActive(false);
                GameManager.Instance.warning_text.text = null;
            }
        }

        if (gun_shoot)
        {
            gun.Shoot();
        }
    }

    /// <summary>
    /// Adds to the current enemy count and updates the UI.
    /// </summary>
    public void addEnemy(int enemy)
    {
        GameManager.Instance.currentEnemy += enemy;
        GameManager.Instance.currentEnemyText.text = "Enemies: " + GameManager.Instance.currentEnemy + "/10";

        if (GameManager.Instance.currentEnemy == 6)
        {
            level1_teleporter.SetActive(true);
        }

        if (GameManager.Instance.currentEnemy == 10)
        {
            GameManager.Instance.currentEnemyText.color = Color.yellow;
        }
    }

    /// <summary>
    /// Updates the current collectible with the given gun.
    /// </summary>
    public void UpdateCollectible(start_gun newCollectible)
    {
        currentGun = newCollectible;
    }

    /// <summary>
    /// Updates the gun pickup status.
    /// </summary>
    public void gunBoolean(bool reference)
    {
        GameManager.Instance.gun_pickup = reference;
    }

    /// <summary>
    /// Updates the current crystal with the given crystal.
    /// </summary>
    public void UpdateCrystal(crystal newCrystal)
    {
        crystal = newCrystal;
    }

    /// <summary>
    /// Updates the crystal pickup status.
    /// </summary>
    public void crystalBoolean(bool reference)
    {
        GameManager.Instance.crystal_pickup = reference;
    }

    /// <summary>
    /// Handles player interactions.
    /// </summary>
    void OnInteract()
    {
        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
            currentDoor = null;
        }

        if (collectible != null)
        {
            if (collectible.tag == "Collectible")
            {
                collectible.Collectible(this);
            }
            else if (collectible.tag == "Door")
            {
                collectible.ChangeScene();
            }
        }
    }

    /// <summary>
    /// Handles shooting the gun.
    /// </summary>
    void OnShoot()
    {
        gun.Shoot();
    }

    /// <summary>
    /// Handles dropping of crystal
    /// </summary>
    void OnDrop()
    {
        Debug.Log("g");

        if (final_waterboy != null)
        {
            final_waterboy.crystal_drop = true;
        }
    }

    /// <summary>
    /// Updates the current door with the given door.
    /// </summary>
    public void UpdateDoor(door newDoor)
    {
        currentDoor = newDoor;
    }
}