/*
* Author:  Sung Yeji
* Date: 2/06/2024
* Description: This script is for the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn_point;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("killfloor");
            player.transform.position = respawn_point.transform.position;
            Physics.SyncTransforms();
        }
    }
}
