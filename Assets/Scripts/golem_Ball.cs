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
    public GameObject projectile;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            TakeDamage(3);
            Debug.Log(GameManager.Instance.currentHealth);
            Destroy(projectile);
        }

        else
        {
            Destroy(projectile, 2f);
        }
    }



    private void Update()
    {
        
    }
}
