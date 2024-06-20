using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource gravel_walk, gravel_run;

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            gravel_walk.enabled = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                gravel_walk.enabled = false;
                gravel_run.enabled = true;
            }
            else
            {
                gravel_walk.enabled = true;
                gravel_run.enabled = false;
            }
        }
        else
        {
            gravel_walk.enabled = false;
            gravel_run.enabled = false;
        }
    }
}
