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

public class door : Interactable
{
    bool opened = false;

    //public TextMeshProUGUI notificationText;
    [SerializeField] GameObject approval_img;
    [SerializeField] GameObject door_object;

    public player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void View()
    {
        base.View();

        // If the object entering the trigger has "Player"
        // and has no gun collected
        if (GameManager.Instance.gun_pickup == false)
        {
            Debug.Log(GameManager.Instance.gun_pickup);
            // Turn on warning UI
            GameManager.Instance.warning_text.text = ("Find the Gun!");
        }

        else
        {
            // Update the player which door the player is in front of
            GameManager.Instance.warning_text.text = ("Press E to Interact");
            player.UpdateDoor(this);
        }

    }

    public override void ChangeScene()
    {
        if (GameManager.Instance.gun_pickup)
        {
            base.ChangeScene();
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
