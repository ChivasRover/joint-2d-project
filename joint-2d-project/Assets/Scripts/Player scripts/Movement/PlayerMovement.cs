using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D Controller;
    public Animator Animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false,
        crouch = false;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        Controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
