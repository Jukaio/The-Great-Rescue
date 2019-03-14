using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStatus : MonoBehaviour
{
    public GameObject deathSound;
    public float healthPoints;
    public GameObject powerUp;
    public GameObject bloodEffect;
    int rndNmbr;
    const float m_dropChance = 1f / 2f; // 50% chance, change to 1f / 10f for 10% chance etc.. .. .. . . .. . 
    // Update is called once per frame



    void Update()
    {
        
        //Death check
        if (healthPoints <= 0)
        {

            if (gameObject != null)
            {
                Instantiate(deathSound, gameObject.transform.position, Quaternion.identity);
                OnEnemyJustDied(); 
                Destroy(gameObject);
            }

        }

        if (gameObject.transform.position.x <= -11)
            Destroy(gameObject);
    }

    private void OnEnemyJustDied()
    {
        //drop power up
        if (Random.Range(0f, 1f) <= m_dropChance)
        {
            Debug.Log("DROP GRATZ");
            powerUp = (GameObject)Instantiate(powerUp, gameObject.transform.position, Quaternion.identity);
        }

    }

    

    //Damage methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            healthPoints = ApplyDamage(healthPoints, collision.GetComponent<BulletMoverPlayer>().damage);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatus>().specialBar += 1;

            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }
            

        else if (collision.gameObject.tag == "PlayerSword")
        {
            Debug.Log("Shot hit!");
            healthPoints = ApplyDamage(healthPoints, collision.GetComponent<swordAttack>().damage);
        }
    }

    float ApplyDamage(float health, float damage)
    {
        return health - damage;
    }

}
