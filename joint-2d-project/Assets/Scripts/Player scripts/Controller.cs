using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
        }     
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
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
}
