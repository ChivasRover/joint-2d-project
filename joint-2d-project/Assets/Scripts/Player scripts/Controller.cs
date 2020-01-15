using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator AnimatorController;
    public GameObject FireController;
    public GameObject Bullet;
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
            speedX = horizontalSpeed;
            isRunning1 = true;
            if (transform.localEulerAngles.y == 0)
                transform.Rotate(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            isRunning1 = true;
            if (transform.localEulerAngles.y == 180)
                transform.Rotate(0f, -180f, 0f);
        }
        else { isRunning1 = false; }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
        if (Input.GetKey(KeyCode.Space))
        { 
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Earth")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Earth")
        {
            isGrounded = false;
        }
    }
    private void Shoot()
    {
        Instantiate(Bullet, FireController.transform.position, FireController.transform.rotation);
    }
}
