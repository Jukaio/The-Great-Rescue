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
        if(GameObject.Find("Player").GetComponent<PlayerController>().damageBuff== true)
        {
            damage *= GameObject.Find("Player").GetComponent<PlayerController>().damageMultiplier;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(tag == "PlayerBullet")
        {
            bulletMovement.moveRight(speed);

            if (gameObject.transform.position.x >= 11)
                Destroy(gameObject);
        }
        else if(tag == "Enemy")
        {
            bulletMovement.moveLeft(speed);

            if (gameObject.transform.position.x <= -11)
                Destroy(gameObject);
        }
        
    }

}
