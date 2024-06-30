/*
* Author: Sung Yeji
* Date: 27/06/2024
* Description: Script for Transition of Scene (Child script) 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Level1_Transition : Interactable 
{
    /// <summary>
    /// An override code of the View function
    /// </summary>
    public override void View()
    {
        base.View();
        GameManager.Instance.warning_text.text = ("Press E to Interact");

    }
}
