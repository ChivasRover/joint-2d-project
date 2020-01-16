using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int Health = 3;
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if(Health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        //Die logic;
    }
}
