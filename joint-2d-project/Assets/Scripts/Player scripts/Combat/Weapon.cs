using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isReadyToAttack = true;
    public float attackDelay = 1f;
    public float attackAnimationTimeOut = 0.5f;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire"))
        {
            if(isReadyToAttack)
            {
                Shoot();
                isReadyToAttack = false;
                Invoke("getReadyToAttack", attackDelay);
            }
        }
    }
    void Shoot()
    {
        animator.SetBool("isAttacking", true);
        Invoke("spawnBullet", attackAnimationTimeOut);
    }
    private void spawnBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("isAttacking", false);
    }
    private void getReadyToAttack() => isReadyToAttack = true;
}
