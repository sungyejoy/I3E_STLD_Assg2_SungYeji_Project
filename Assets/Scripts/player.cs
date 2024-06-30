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

    /// <summary>
    /// Store the current door in front of the player
    /// </summary>
    door currentDoor;
    Interactable collectible;

    start_gun currentGun;

    crystal crystal;

    //public bool gun_pickup = false;

    [SerializeField] Transform main_camera;
    [SerializeField] float interactionDistance;
    [SerializeField] GameObject level1_teleporter;

    int max_distance = 5;

    bool gun_shoot = false;
    public Gun gun;

    //public float threshold;

    // Start is called before the first frame update
    void Start()
    {
        /// <summary>
        /// Turn on UI
        /// </summary>
        GameManager.Instance.currentEnemyText.text = "Enemies: " + GameManager.Instance.currentEnemy + "/20";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(main_camera.position, main_camera.position + (main_camera.forward * interactionDistance), Color.red);
        
        //if (transform.position.y < threshold)
        //{
            //transform.position = new Vector3(-69.63f, 4.15f, -54.38f);
        //}

        RaycastHit hit;

        if (Physics.Raycast(main_camera.transform.position, main_camera.transform.forward, out hit, max_distance))
        {
            //Debug.Log(hit.transform.name);

            if (hit.transform.TryGetComponent<Interactable>(out collectible))
            {
                if (hit.transform.tag == "Collectible")
                {
                    GameManager.Instance.warning_img.SetActive(true);
                    GameManager.Instance.warning_text.text = collectible.text.ToString();
                }

                else if(hit.transform.tag == "Door")
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

    public void addEnemy(int enemy)
    {
        GameManager.Instance.currentEnemy += enemy;
        GameManager.Instance.currentEnemyText.text = "Enemies: " + GameManager.Instance.currentEnemy + "/20";

        if (GameManager.Instance.currentEnemy == 6)
        {
            level1_teleporter.SetActive(true);
        }

        // Once all friend bees are found, font color changes
        if (GameManager.Instance.currentEnemy == 20)
        {
            GameManager.Instance.currentEnemyText.color = Color.yellow;
        }
    }

    // Connects object that has HoneypotKey script
    public void UpdateCollectible(start_gun newCollectible)
    {
        currentGun = newCollectible;
    }

    // Reference to see if the honeypot key was picked up or not
    public void gunBoolean(bool reference)
    {
        GameManager.Instance.gun_pickup = reference;
    }

    public void UpdateCrystal(crystal newCrystal)
    {
        crystal = newCrystal;
    }
    public void crystalBoolean(bool reference)
    {
        GameManager.Instance.crystal_pickup = reference;
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


        if(collectible != null)
        {
            if (collectible.tag == "Collectible")
            {
                Debug.Log("collectible");
                collectible.Collectible(this);
            }

            else if (collectible.tag == "Door")
            {
                Debug.Log("door");
                collectible.ChangeScene();
            }

        }
        
    }

    void OnShoot()
    {
        gun.Shoot();
    }

        public void UpdateDoor(door newDoor)
    {
        currentDoor = newDoor;
    }
}
