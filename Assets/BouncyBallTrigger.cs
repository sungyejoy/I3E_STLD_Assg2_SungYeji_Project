/*
* Author: Sung Yeji
* Date: 29/06/2024
* Description: Script to start trigger of the bouncy balls
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the behavior of a bouncy ball trigger, which activates and deactivates a bounce barrier
/// based on player interactions.
/// </summary>
public class BouncyBallTrigger : MonoBehaviour
{
    /// <summary>
    /// The bounce barrier GameObject that will be activated or deactivated.
    /// </summary>
    [SerializeField] GameObject bounceBarrier;

    /// <summary>
    /// Start is called before the first frame update. Activates the bounce barrier.
    /// </summary>
    void Start()
    {
        bounceBarrier.SetActive(true);
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to the object this script is attached to.
    /// Deactivates the bounce barrier if the player enters the trigger.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bounceBarrier.SetActive(false);
        }
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to the object this script is attached to.
    /// Destroys the game object when the player exits the trigger.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }

}

