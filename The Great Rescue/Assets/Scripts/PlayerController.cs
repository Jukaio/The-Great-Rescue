﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Experimental.UIElements;
using System;


//public enum myEnum // your custom enumeration
//{
//    Rigidbody,
//    CharacterController,
//};



public class PlayerController : MonoBehaviour


{
    [Tooltip("if selected, it creates a Rigidbody instead of a Character Controller")]
    public bool ifRigidbody;
    [Tooltip("if selected, it adds force to the Rigidbody. It causes acceleration")]
    public bool acceleration;

    Movement playerMovement;
    private CharacterController charController; // <- work on this, David!
    Rigidbody2D rb2d;
    public float speed;
    Vector3 moveDirection = Vector3.zero;



    void Start()
    {

        if (ifRigidbody == true)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.gravityScale = 0;
            


        }
        else if (ifRigidbody == false)
            charController = gameObject.AddComponent<CharacterController>();

        
        playerMovement = gameObject.GetComponent<Movement>();
    

    }
    void Update()
    {
        if (ifRigidbody == true && acceleration == true)
            //playerMovement.movingWithRb2d(rb2d, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), speed);

            rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f),
                                                Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 0.8f));

        else if (ifRigidbody == true && acceleration == false)
            playerMovement.movingWithoutRB(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), speed);

        else if (ifRigidbody == false)
        {
            

        }
    }





}

