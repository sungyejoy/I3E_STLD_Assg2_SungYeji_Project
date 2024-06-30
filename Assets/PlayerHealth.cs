/*
* Author:  Sung Yeji
* Date: 23/06/2024
* Description: This script is for the player health
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the player's health, including taking damage and handling death.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Initializes the player's health to the maximum value at the start of the game.
    /// </summary>
    void Start()
    {
        GameManager.Instance.currentHealth = GameManager.Instance.maxHealth;
    }

    /// <summary>
    /// Reduces the player's health by the specified amount.
    /// </summary>
    public void TakeDamage(float amount)
    {
        GameManager.Instance.currentHealth -= amount;

        if (GameManager.Instance.currentHealth <= 0)
        {
            // Die
            Debug.Log("Player Dead");
        }
    }
}
