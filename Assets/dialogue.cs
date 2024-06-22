/*
* Author: Sung Yeji
* Date: 22/06/2024
* Description: Script for Dialogue
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogue : MonoBehaviour
{
    /// <summary>
    /// Stating the UI elements
    /// </summary>
    [SerializeField] GameObject dialogue_img;
    public TextMeshProUGUI dialogue_text;
    [SerializeField] GameObject step_1;
    [SerializeField] GameObject step_2;
    [SerializeField] GameObject step_3;
    [SerializeField] GameObject step_4;

    // Start is called before the first frame update
    void Start()
    {
        step_1.SetActive(false);
        step_2.SetActive(false);
        step_3.SetActive(false);
        step_4.SetActive(false);
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
            dialogue_text.text = "What was that explosion sound just now? Oh no...";
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
            step_1.SetActive(true);
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
