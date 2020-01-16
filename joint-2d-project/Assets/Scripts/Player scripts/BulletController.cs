using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 20f;
    public int Damage = 1;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Enemy")
        {
            EnemyBehaviour enemy1 = collision.GetComponent<EnemyBehaviour>();
            if(enemy1 != null)
                enemy1.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
