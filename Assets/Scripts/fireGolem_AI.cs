/*
 * Author:  Sung Yeji
 * Date: 21/06/2024
 * Description: This script is for the Fire Golem enemy using AI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fireGolem_AI : MonoBehaviour
{
    public NavMeshAgent firegolem;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    /// <summary>
    /// A float of the enemy's total health
    /// </summary>
    public float health = 50f; 

    // Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    /// <summary>
    /// AudioSource for the sound of fire golem dying
    /// </summary>
    public AudioSource golem_die;

    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        firegolem = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            firegolem.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        firegolem.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        firegolem.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        golem_die.enabled = true;

        /// <summary>
        /// When the gun shoots at the Fire Golem, health will be deducted
        /// </summary>
        if (health <= 0f)
        {
            /// <summary>
            /// If the enemy health is lower than 0, it will perish
            /// </summary>
            DestroyEnemy();
            golem_die.enabled = true;
        }
    }

    private void DestroyEnemy()
    {
        /// <summary>
        /// The function Die() destroys the enemy itself
        /// </summary>
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
