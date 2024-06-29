using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.currentHealth = GameManager.Instance.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        GameManager.Instance.currentHealth -= amount;

        if(GameManager.Instance.currentHealth <= 0)
        {
            // Die
            Debug.Log("Player Dead");
        }
    }

}
