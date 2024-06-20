/*
 * Author:  Sung Yeji
 * Date: 15/06/2024
 * Description: This script is for the Fire Golem enemy
 */

using UnityEngine;

public class fireGolem : MonoBehaviour
{
    /// <summary>
    /// A float of the enemy's total health
    /// </summary>
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        /// <summary>
        /// When the gun shoots at the Fire Golem, health will be deducted
        /// </summary>
        health -= amount;
        if(health <= 0f)
        {
            /// <summary>
            /// If the enemy health is lower than 0, it will perish
            /// </summary>
            Die();
        }
    }

    void Die()
    {
        /// <summary>
        /// The function Die() destroys the enemy itself
        /// </summary>
        Destroy(gameObject);
    }
}
