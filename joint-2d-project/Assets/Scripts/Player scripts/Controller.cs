using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator AnimatorController;
    public SpriteRenderer SpriteRendererController;
    public Transform FirePoint;
    public int Health = 100;
    public int Damage = 40; 
    private bool isRunning1
    {
        get { return AnimatorController.GetBool("isRunning"); }
        set { AnimatorController.SetBool("isRunning", value); }
    }

    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;
            isRunning1 = true;
            SpriteRendererController.flipX = true;
            if (FirePoint.rotation.y == 0f)
            {
                FirePoint.Rotate(0f, 180f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            isRunning1 = true;
            SpriteRendererController.flipX = false;
            if (FirePoint.rotation.y == 180f)
            {
                FirePoint.Rotate(0f, 180f, 0f);
            }
        }
        else { isRunning1 = false; }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
        //Debug.Log("isRunning == " + isRunning1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Earth")
        {
            isGrounded = true;
           // Debug.Log("IsGrounded == " + isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Earth")
        {
            isGrounded = false;
            Debug.Log("IsGrounded == " + isGrounded);
        }
    }
    public void Shoot()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
        Debug.Log(HitInfo.transform.GetComponent<EnemyBehaviour>());
        EnemyBehaviour enemy1 = HitInfo.transform.GetComponent<EnemyBehaviour>();
        if (enemy1 != null)
        {
            enemy1.TakeDamage(Damage);
        }
    }
    public void TakeDamage(int Damage1)
    {
        Health -= Damage1;
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //logic
    }
}
