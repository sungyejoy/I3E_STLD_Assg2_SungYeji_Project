/*
* Author: Sung Yeji
* Date: 23/06/2024
* Description: Script for the projectile that golems throw
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

/// <summary>
/// Represents a projectile fired by a golem that interacts with the player's health.
/// </summary>
public class golem_Ball : PlayerHealth
{
    /// <summary>
    /// The projectile GameObject fired by the golem.
    /// </summary>
    public GameObject projectile;

    /// <summary>
    /// Start is called before the first frame update. Currently empty.
    /// </summary>
    private void Start()
    {
        // Start method is currently empty
    }

    /// <summary>
    /// Called when another collider collides with the projectile's collider.
    /// Deals damage to the player if the collision is with the player object.
    /// Destroys the projectile after causing damage.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(3); // Damage the player
            Destroy(projectile); // Destroy the projectile after hitting the player
        }
        else
        {
            Destroy(projectile, 2f); // Destroy the projectile after 2 seconds if it doesn't hit the player
        }
    }

}