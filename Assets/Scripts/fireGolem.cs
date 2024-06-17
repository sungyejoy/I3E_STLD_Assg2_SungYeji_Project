
using UnityEngine;

public class fireGolem : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        Debug.Log("hi");

        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
