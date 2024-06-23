using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class golem_Ball : MonoBehaviour
{
    [SerializeField] GameObject currentHealth;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //currentHealth = collision.GetComponent<PlayerHealth>();

            if(currentHealth != null)
            {
                //currentHealth.TakeDamage(10);
            }
        }
    }



    private void Update()
    {
        
    }
}
