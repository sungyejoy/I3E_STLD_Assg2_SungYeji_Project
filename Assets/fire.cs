using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : PlayerHealth
{
    float timeOverDamage = 0;
    float nextDamageTime = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(5);
            GameManager.Instance.hurt_audio.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FireDamageOverTime();
        }
    }
    
    private void FireDamageOverTime()
    {
        if(Time.time >= timeOverDamage && GameManager.Instance.currentHealth > 0)
        {
            timeOverDamage = Time.time + 1/nextDamageTime;
            TakeDamage(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
