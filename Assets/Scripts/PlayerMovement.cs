using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //private Animator anim;

    public float runSpeed = 40;
    public float jumpForce = 500;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            //anim.SetBool("Crouching", true);

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            //anim.SetBool("Crouching", false);

        }
    }

    private void FixedUpdate()
    {
        // Move the Player
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, jumpForce);
        jump = false;
    }
}
