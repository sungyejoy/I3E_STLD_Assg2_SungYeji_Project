/*
* Author: Sung Yeji
* Date: 22/06/2024
* Description: Script for Dialogue
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue4 : MonoBehaviour
{
    /// <summary>
    /// Stating the UI elements
    /// </summary>
    [SerializeField] GameObject dialogue_img;
    public TextMeshProUGUI dialogue_text;

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
            dialogue_img.SetActive(true);
            dialogue_text.text = "Thank goodness I have my Unlimited Ammo Neon Gun with me.";
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
            dialogue_img.SetActive(false);
            dialogue_text.text = null;
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
