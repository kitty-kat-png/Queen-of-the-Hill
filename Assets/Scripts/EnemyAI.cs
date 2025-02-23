using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int foodReward = 10;  // Food to reward the player upon defeat
    public GameObject player;  // Reference to the player
    public int health = 100;  // Enemy health
    public float detectionRange = 5f;
    public LayerMask obstacleMask;
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public Animator animator;

    private int currentPatrolIndex = 0;
    private bool playerInSight = false;
    private bool isChasing = false;

    void Update()
    {
        CheckForPlayer();

        if (playerInSight)
        {
            animator.SetTrigger("Alert");  // Play detection animation
            isChasing = true;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void OnDeath()
    {
        // Call the player's food system to add food
        FoodManager playerFood = player.GetComponent<FoodManager>();
        if (playerFood != null)
        {
            playerFood.AddFood(foodReward);  // Reward food to the player
        }

        // Destroy the enemy object
        Destroy(gameObject);
    }

    // This method is called when the enemy takes damage
    public void TakeDamage(int damage)
    {
        health -= damage;  // Subtract the damage from the enemy's health

        // If health is 0 or less, the enemy dies
        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void CheckForPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= detectionRange)
        {
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, obstacleMask);

            Debug.DrawRay(transform.position, directionToPlayer * detectionRange, Color.red, 0.1f); // 0.1 sec visibility

            if (hit.collider != null)
            {
                if (hit.collider.transform == player.transform)
                {
                    playerInSight = true;
                    return;
                }
            }
        }
        playerInSight = false;
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
    }
}

