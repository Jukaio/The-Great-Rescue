using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneController : MonoBehaviour
{
    public float healthPoints;
    public float speed;
    private Movement stoneMovement;
    
    void Start()
    {
        stoneMovement = gameObject.AddComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        stoneMovement.moveLeft(speed);

        //Death check
        if (healthPoints == 0)
            Destroy(gameObject);
        if (gameObject.transform.position.x <= -11)
            Destroy(gameObject);
    }


    //Damage methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
            healthPoints = ApplyDamage(healthPoints, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
            healthPoints = ApplyDamage(healthPoints, 1);
    }

    float ApplyDamage(float health, float damage)
    {
        return health - damage;
    }
}
