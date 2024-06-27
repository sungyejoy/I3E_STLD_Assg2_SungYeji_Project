using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : PlayerHealth
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("fire");
            TakeDamage(10);
            //GameManager.Instance.hurt_audio.Play();
            Debug.Log(currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
