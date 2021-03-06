﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoverPlayer : MonoBehaviour
{
    public float speed;
    public float damage;

    void Start()
    {
        if (GameObject.Find("PlayerBody").GetComponent<playerStatus>().damageBuff == true)
        {
            damage *= GameObject.Find("PlayerBody").GetComponent<playerStatus>().damageMultiplier;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);

        if (gameObject.transform.position.x >= 10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "Enemy")
        { 
            Destroy(gameObject);
        }
        if (collision.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
