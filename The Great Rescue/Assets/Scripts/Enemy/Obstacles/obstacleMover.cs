﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMover : MonoBehaviour
{
    public float speed;


    void Update()
    {
        Vector2 movement = new Vector2(-1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    //    if (collision.gameObject.tag == "Player")
    //        Destroy(gameObject);
    }
}
