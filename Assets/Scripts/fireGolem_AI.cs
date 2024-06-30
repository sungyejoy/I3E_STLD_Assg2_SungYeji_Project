/*
* Author:  Sung Yeji
* Date: 21/06/2024
* Description: This script is for the Fire Golem enemy using AI
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls the behavior of the fire golem enemy, including patrolling, chasing, and attacking the player.
/// </summary>
public class fireGolem_AI : MonoBehaviour
{
    /// <summary>
    /// The NavMeshAgent component used for pathfinding.
    /// </summary>
    public NavMeshAgent firegolem;

    /// <summary>
    /// The player's transform.
    /// </summary>
    public Transform player;

    /// <summary>
    /// The layer mask to identify the player.
    /// </summary>
    public LayerMask whatIsPlayer;

    /// <summary>
    /// The spawn point for the projectile.
    /// </summary>
    public GameObject ball_spawn;

    /// <summary>
    /// The enemy's total health.
    /// </summary>
    public float health = 50f;

    /// <summary>
    /// The number of enemies.
    /// </summary>
    public int enemy = 1;

    // Patrolling
    /// <summary>
    /// The current walk point for patrolling.
    /// </summary>
    public Vector3 walkPoint;

    /// <summary>
    /// Whether a walk point has been set.
    /// </summary>
    bool walkPointSet;

    /// <summary>
    /// The range within which to set a walk point.
    /// </summary>
    public float walkPointRange;

    // Attacking
    /// <summary>
    /// Time between attacks.
    /// </summary>
    public float timeBetweenAttacks;

    /// <summary>
    /// Whether the golem has already attacked.
    /// </summary>
    bool alreadyAttacked;

    /// <summary>
    /// The projectile GameObject to be fired.
    /// </summary>
    public GameObject projectile;

    // States
    /// <summary>
    /// The sight range for detecting the player.
    /// </summary>
    public float sightRange;

    /// <summary>
    /// The attack range for attacking the player.
    /// </summary>
    public float attackRange;

    /// <summary>
    /// Whether the player is within sight range.
    /// </summary>
    public bool playerInSightRange;

    /// <summary>
    /// Whether the player is within attack range.
    /// </summary>
    public bool playerInAttackRange;

    /// <summary>
    /// The sound of the fire golem dying.
    /// </summary>
    [SerializeField] private AudioClip golem_die;

    /// <summary>
    /// The level 1 teleporter
    /// </summary>
    [SerializeField] GameObject level1_teleporter;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        firegolem = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    /// <summary>
    /// Handles patrolling behavior of the golem.
    /// </summary>
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

    /// <summary>
    /// Searches for a random walk point within the range.
    /// </summary>
    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f))
            walkPointSet = true;
    }

    /// <summary>
    /// Handles chasing the player.
    /// </summary>
    private void ChasePlayer()
    {
        firegolem.SetDestination(player.position);
    }

    /// <summary>
    /// Handles attacking the player.
    /// </summary>
    private void AttackPlayer()
    {
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

    /// <summary>
    /// Resets the attack cooldown.
    /// </summary>
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    /// <summary>
    /// Handles taking damage for the golem.
    /// </summary>
    public void TakeDamage(float amount)
    {
        health -= amount;

        // When the gun shoots at the Fire Golem, health will be deducted
        if (health <= 0f)
        {
            Debug.Log("enemy health 0");
            // If the enemy health is lower than 0, it will perish
            AudioSource.PlayClipAtPoint(golem_die, transform.position, 1f);
            DestroyEnemy();
        }
    }

    /// <summary>
    /// Destroys the enemy and adds to the player's enemy count.
    /// </summary>
    private void DestroyEnemy()
    {
        
        GameManager.Instance.currentEnemy += enemy;
        GameManager.Instance.currentEnemyText.text = "Enemies: " + GameManager.Instance.currentEnemy + "/10";

        if (GameManager.Instance.currentEnemy == 6)
        {
            level1_teleporter.SetActive(true);
        }

        if (GameManager.Instance.currentEnemy == 10)
        {
            GameManager.Instance.currentEnemyText.color = Color.yellow;
        }

        Destroy(gameObject);
    }
}