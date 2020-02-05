﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float attackAnimationTimeOut = 1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Shoot();
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
}
