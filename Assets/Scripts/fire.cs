/*
* Author:  Sung Yeji
* Date: 26/06/2024
* Description: This script is for the Fire that damages the player over time
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling the fire hazard that damages the player over time.
/// Inherits from the PlayerHealth class.
/// </summary>
public class fire : PlayerHealth
{
    /// <summary>
    /// Tracks the next time the player will take damage from fire.
    /// </summary>
    float timeOverDamage = 0;

    /// <summary>
    /// Interval between consecutive damage ticks.
    /// </summary>
    float nextDamageTime = 0.75f;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this object.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TakeDamage(5);
            GameManager.Instance.hurt_audio.Play();
        }
    }

    /// <summary>
    /// Called once per frame for every collider that is touching the trigger collider attached to this object.
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FireDamageOverTime();
        }
    }

    /// <summary>
    /// Applies damage to the player over time while they stay in the fire.
    /// </summary>
    private void FireDamageOverTime()
    {
        if (Time.time >= timeOverDamage && GameManager.Instance.currentHealth > 0)
        {
            timeOverDamage = Time.time + 1 / nextDamageTime;
            TakeDamage(5);
        }
    }
}
