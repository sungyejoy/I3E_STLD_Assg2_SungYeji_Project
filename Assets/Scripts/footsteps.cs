/*
 * Author:  Sung Yeji
 * Date: 20/06/2024
 * Description: This script is for the player's footsteps on gravel
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    /// <summary>
    /// AudioSource for the sound of walking and running on gravel
    /// </summary>
    public AudioSource gravel_walk, gravel_run;

    void Update()
    {
        /// <summary>
        /// When W, A, S, D is pressed, the following events will happen
        /// </summary>
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                /// <summary>
                /// When left shift is pressed, run audio will be enabled
                /// </summary>
                gravel_walk.enabled = false;
                gravel_run.enabled = true;
            }
            else
            {
                /// <summary>
                /// When left shift is not pressed, walk audio will be enabled
                /// </summary>
                gravel_walk.enabled = true;
                gravel_run.enabled = false;
            }
        }
        else
        {
            /// <summary>
            /// When no buttons are pressed, no audio will be enabled
            /// </summary>
            gravel_walk.enabled = false;
            gravel_run.enabled = false;
        }
    }
}
