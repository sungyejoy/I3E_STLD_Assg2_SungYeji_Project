/*
* Author:  Sung Yeji
* Date: 26/06/2024
* Description: This script is for the Setting Menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Handles the settings menu functionality.
/// </summary>
public class SettingMenu : MonoBehaviour
{
    /// <summary>
    /// The audio mixer to control the volume.
    /// </summary>
    public AudioMixer audioMixer;

    /// <summary>
    /// Sets the volume of the audio mixer.
    /// </summary>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
