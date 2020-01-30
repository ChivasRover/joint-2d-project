using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health = 3;
    public int damagePower;
    public GameObject enemy;
    public GameObject coin;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //Die logic
        Instantiate(coin, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
