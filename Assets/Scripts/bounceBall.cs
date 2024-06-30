/*
* Author:  Sung Yeji
* Date: 29/06/2024
* Description: This script is for the bouncy balls using physics material
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script attached to a bouncing ball that causes damage to the player upon collision.
/// Inherits functionality from PlayerHealth for health-related operations.
/// </summary>
public class bounceBall : PlayerHealth
{
    /// <summary>
    /// The initial force applied to the ball upon start.
    /// </summary>
    public Vector3 startForce;

    // Start is called before the first frame update
    void Start()
    {
        // Add initial force to the ball rigidbody
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check collision with player
        if (collision.gameObject.tag == "Player")
        {
            // Deal damage to the player upon collision
            TakeDamage(15);
        }
    }
}

