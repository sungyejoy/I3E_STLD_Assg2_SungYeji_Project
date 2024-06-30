/*
* Author:  Sung Yeji
* Date: 23/06/2024
* Description: This script is for the slider of the Player Health
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the visual representation of the player's health status using a Slider and Image.
/// </summary>
public class FilllStatusBar : MonoBehaviour
{
    /// <summary>
    /// Reference to the PlayerHealth script for accessing health information.
    /// </summary>
    public PlayerHealth playerHealth;

    /// <summary>
    /// The Image component used to display the fill status.
    /// </summary>
    public Image fillImage;

    private Slider slider; // Reference to the Slider component for health representation

    private void Awake()
    {
        slider = GetComponent<Slider>(); // Initialize the Slider component on Awake
    }

    // Update is called once per frame
    void Update()
    {
        // Disable fillImage if slider value is at minimum
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        // Enable fillImage if slider value is above minimum and it's currently disabled
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        // Calculate fill value based on current player health and update slider
        float fillValue = GameManager.Instance.currentHealth / GameManager.Instance.maxHealth;
        slider.value = fillValue;

        // Adjust fillImage color based on health status
        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red; // Change color to red for low health
            GameManager.Instance.hurt.SetActive(true); // Activate hurt indicator if health is low
        }
        else
        {
            fillImage.color = Color.green; // Change color to green for normal health
            GameManager.Instance.hurt.SetActive(false); // Deactivate hurt indicator if health is normal
        }
    }
}
