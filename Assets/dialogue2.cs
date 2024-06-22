/*
* Author: Sung Yeji
* Date: 22/06/2024
* Description: Script for Dialogue
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.Burst.Intrinsics.X86;

public class dialogue2 : MonoBehaviour
{
    /// <summary>
    /// Stating the UI elements
    /// </summary>

    [SerializeField] GameObject step_3;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /// <summary>
        /// Check if what entered the trigger is the Player, 
        /// and if it is turn on dialogue
        /// </summary>
        /// 
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<DialogueBox>().StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /// <summary>
        /// Check if the object exiting the trigger is the Player,
        /// and if it is, turn off dialogue, and destroy game object
        /// </summary>
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
