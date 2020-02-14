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

    void Update()
    {        
        if (Input.GetButtonDown("Fire"))
        {
            if(isReadyToAttack)
            {
                animator.SetBool("isAttacking", true);
            }
        }
    }
    public void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("ShootSound");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
    public void endOfAttack()
    {
        isReadyToAttack = true;
        animator.SetBool("isAttacking", false);
    }
}
