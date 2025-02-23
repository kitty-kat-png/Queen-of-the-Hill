using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyQueen : MonoBehaviour
{
    public int health = 100;  // The Queen's health
    public GameObject winUI;  // UI that shows win message (Optional)

    private void TakeDamage(int damage)
    {
        health -= damage;

        // If health reaches 0 or below, the Queen is defeated
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Trigger the win condition
        Debug.Log("Enemy Queen Defeated! You win!");

        // Show the win UI (you can make this a win screen or a simple message)
        if (winUI != null)
        {
            winUI.SetActive(true);  // Activate the win screen
        }

        // Optionally: End the game (you can restart or show a victory screen)
        Time.timeScale = 0;  // Pause the game (or change this to a scene transition)
    }

    // Example: Call this when player deals damage to the Queen
    public void OnPlayerAttack(int damage)
    {
        TakeDamage(damage);
    }
}
