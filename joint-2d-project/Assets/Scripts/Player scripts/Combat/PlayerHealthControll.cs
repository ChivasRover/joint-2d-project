using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControll : MonoBehaviour
{
    public int playerHealth;
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("Damage, rest is - " + playerHealth);
        if (playerHealth <= 0)
        {
            Die();
            Debug.Log("Player is dead");
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
