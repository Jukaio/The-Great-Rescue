using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStatus : MonoBehaviour
{
    public GameObject deathAnimation;
    public float healthPoints;
    public GameObject powerUp;
    public GameObject bloodEffect;
    int rndNmbr;
    const float m_dropChance = 1f / 2f; // 50% chance, change to 1f / 10f for 10% chance etc.. .. .. . . .. . 
    // Update is called once per frame
    playerStatus PlayerStatus;

    private void Awake()
    {
        PlayerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatus>();
    }

    void Update()
    {
        
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
            PlayerStatus.specialBar += 5;

            deathCheck();
        }
            

        else if (collision.gameObject.tag == "PlayerSword")
        {
            Debug.Log("Shot hit!");
            PlayerStatus.specialBar += 10;
            healthPoints = ApplyDamage(healthPoints, collision.GetComponent<swordAttack>().damage);

            deathCheck();
        }
    }

    void deathCheck()
    {
        if (healthPoints <= 0)
        {

            Instantiate(deathAnimation, gameObject.transform.position, Quaternion.identity);
            OnEnemyJustDied();
            Destroy(gameObject, 0.001f);


        }

        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    float ApplyDamage(float health, float damage)
    {
        return health - damage;
    }

}
