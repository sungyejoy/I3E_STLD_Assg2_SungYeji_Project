/*
* Author:  Sung Yeji
* Date: 29/06/2024
* Description: This script is for the floor that kills the player instantly
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the behavior of a kill floor that respawns the player to a designated point upon collision.
/// </summary>
public class KillFloor : MonoBehaviour
{
    /// <summary>
    /// The player transform that will be repositioned upon collision with the kill floor.
    /// </summary>
    [SerializeField] private Transform player;

    /// <summary>
    /// The respawn point transform where the player will be repositioned to.
    /// </summary>
    [SerializeField] private Transform respawn_point;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to the object this script is attached to.
    /// If the player enters the trigger, they are repositioned to the respawn point.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("killfloor");
            GameManager.Instance.deathUI.SetActive(true);
            //GameManager.Instance.playerCapsule.transform.position = respawn_point.transform.position;
            //Physics.SyncTransforms();
        }
    }
}

