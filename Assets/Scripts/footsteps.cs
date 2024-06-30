/*
* Author:  Sung Yeji
* Date: 20/06/2024
* Description: This script is for the footsteps of the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages footstep sounds based on player input for walking and running on gravel.
/// </summary>
public class footsteps : MonoBehaviour
{
    /// <summary>
    /// AudioSource for walking on gravel.
    /// </summary>
    public AudioSource gravel_walk;

    /// <summary>
    /// AudioSource for running on gravel.
    /// </summary>
    public AudioSource gravel_run;

    void Update()
    {
        /// <summary>
        /// Check if movement keys (W, A, S, D) are pressed.
        /// </summary>
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                /// <summary>
                /// Enable running audio when Left Shift is pressed.
                /// </summary>
                gravel_walk.enabled = false;
                gravel_run.enabled = true;
            }
            else
            {
                /// <summary>
                /// Enable walking audio when Left Shift is not pressed.
                /// </summary>
                gravel_walk.enabled = true;
                gravel_run.enabled = false;
            }
        }
        else
        {
            /// <summary>
            /// Disable all footstep audio when no movement keys are pressed.
            /// </summary>
            gravel_walk.enabled = false;
            gravel_run.enabled = false;
        }
    }
}