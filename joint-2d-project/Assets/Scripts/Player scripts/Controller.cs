using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator AnimatorController;
    public GameObject FireController;
    public GameObject Bullet;
    public float ShootDelay = 0.5f;
    private bool isRunning1
    {
        get { return AnimatorController.GetBool("isRunning"); }
        set { AnimatorController.SetBool("isRunning", value); }
    }
    private bool isAttacking1
    {
        get { return AnimatorController.GetBool("isAttacking"); }
        set { AnimatorController.SetBool("isAttacking", value); }
    }
    private bool isReadyToAttack = true;

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
            if (FireController.transform.localEulerAngles.y == 0)
                FireController.transform.Rotate(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            isRunning1 = true;
            if (transform.localEulerAngles.y == 180)
                transform.Rotate(0f, -180f, 0f);
            if (FireController.transform.localEulerAngles.y == 180)
                FireController.transform.Rotate(0f, -180f, 0f);
        }
        else { isRunning1 = false; }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
        if (Input.GetKey(KeyCode.Space) && isReadyToAttack)
        {
            Shoot();
            isReadyToAttack = false;
            //isAttacking1 = true;
            //StartCoroutine(ShootAnimationDelay(0.85f));
            //StartCoroutine(BulletSpawnDelay(0.7f));
            StartCoroutine(ReadyToAttackDelay(ShootDelay));

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
    //IEnumerator BulletSpawnDelay(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    Shoot();
    //}
    //IEnumerator ShootAnimationDelay(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    isAttacking1 = false;
    //}

    IEnumerator ReadyToAttackDelay(float time)
    {
        yield return new WaitForSeconds(time);
        isReadyToAttack = true;
    }
}
