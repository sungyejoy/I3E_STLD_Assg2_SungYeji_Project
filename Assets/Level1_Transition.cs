/*
* Author: Sung Yeji
* Date: 27/06/2024
* Description: Script for Door 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Level1_Transition : Interactable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void View()
    {
        //base.View();
        GameManager.Instance.warning_text.text = ("Press E to Interact");

    }


}
