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

    public LayerMask whatIsPlayer;

    public GameObject ball_spawn;

    /// <summary>
    /// A float of the enemy's total health
    /// </summary>
    public float health = 50f;
    public int enemy = 1;

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
    [SerializeField] private AudioClip golem_die;
    [SerializeField] private AudioClip golem_groan;

    public player Player;

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

        if (Physics.Raycast(walkPoint, -transform.up, 2f))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {

        firegolem.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //AudioSource.PlayClipAtPoint(golem_groan, transform.position, 1f);

        firegolem.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here
            Rigidbody rb = Instantiate(projectile, ball_spawn.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        /// <summary>
        /// When the gun shoots at the Fire Golem, health will be deducted
        /// </summary>
        if (health <= 0f)
        {
            /// <summary>
            /// If the enemy health is lower than 0, it will perish
            /// </summary>
            AudioSource.PlayClipAtPoint(golem_die, transform.position, 1f);
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        /// <summary>
        /// The function Die() destroys the enemy itself
        /// </summary>
        //GetComponent<player>().addEnemy(enemy);

        Player.addEnemy(1);


        Destroy(gameObject);

    }
}
