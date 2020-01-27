using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health = 3;
    public GameObject enemy;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //Die logic
        Destroy(gameObject);
    }
}
