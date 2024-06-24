/*
* Author: Sung Yeji
* Date: 23/06/2024
* Description: Script for Door 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class golem_Ball : PlayerHealth
{

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TakeDamage(10);
            Debug.Log(currentHealth);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject, 5f);
        }
    }



    private void Update()
    {
        
    }
}
