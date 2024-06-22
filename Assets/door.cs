/*
* Author: Sung Yeji
* Date: 22/06/2024
* Description: Script for Door 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class door : MonoBehaviour
{
    bool opened = false;

    public TextMeshProUGUI notificationText;
    [SerializeField] GameObject approval_img;
    [SerializeField] GameObject warning_img;
    [SerializeField] GameObject door_object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the object entering the trigger has "Player"
        // and has no gun collected
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<player>().gun_pickup == false)
            {
                // Turn on warning UI
                warning_img.SetActive(true);
                notificationText.text = ("Find the Gun!");
            }

            else
            {
                // Turn on warning UI
                warning_img.SetActive(true);
                notificationText.text = ("Press E to open door");

                // Update the player which door the player is in front of
                other.gameObject.GetComponent<player>().UpdateDoor(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has "Player"
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player>().UpdateDoor(null);

            // Turn off UI when player exits trigger
            approval_img.SetActive(false);
            warning_img.SetActive(false);
            notificationText.text = null;
        }
    }

    public void SetLock(bool lockStatus)
    {
        opened = lockStatus;
    }

    public void OpenDoor()
    {
        if (!opened)
        {
            Debug.Log("Door open");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
