/*
* Author: Sung Yeji
* Date: 30/06/2024
* Description: Script to start the stopwatch when player exits the trigger 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is for triggering the stopwatch when the player exits a specific area.
/// </summary>
public class stopwatchTrigger : MonoBehaviour
{

    /// <summary>
    /// Called when another collider exits the trigger collider attached to the object this script is attached to.
    /// Sets the stopwatch to true in the GameManager.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.stopwatch = true;
    }

}
