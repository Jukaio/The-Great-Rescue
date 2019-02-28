using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;
    private Movement bulletMovement;


    public float damage;

    void Start()
    {
        bulletMovement = gameObject.AddComponent<Movement>();
        if (GameObject.Find("PlayerBody").GetComponent<playerStatus>().damageBuff == true)
        {
            damage *= GameObject.Find("PlayerBody").GetComponent<playerStatus>().damageMultiplier;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "PlayerBullet")
        {
            bulletMovement.moveRight(speed);

            if (gameObject.transform.position.x >= 11)
                Destroy(gameObject);
        }
        else if (tag == "EnemyBullet")
        {
            bulletMovement.moveLeft(speed);

            if (gameObject.transform.position.x <= -11)
                Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "PlayerBullet")
        {
            if (collision.gameObject.tag == "Enemy" && collision.gameObject.layer != 8)
                Destroy(gameObject);
        }
        else if (tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.layer != 8)
                Destroy(gameObject);
        }
    }
}
