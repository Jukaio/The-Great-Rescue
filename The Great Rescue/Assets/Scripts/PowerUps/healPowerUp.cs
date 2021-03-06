﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPowerUp : MonoBehaviour
{
    public float speed;
    public float healAmount;
    public GameObject sound;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 movement = new Vector2(-1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<playerStatus>().healthPoints < 10)
            {
                Instantiate(sound, gameObject.transform.position, Quaternion.identity);
                collision.gameObject.GetComponent<playerStatus>().healthPoints += healAmount;
                HealthBarScript.health += 10;
                CooldownHeal.healCoolingDown = true;
                Destroy(gameObject);
            }
        }
    }

}
