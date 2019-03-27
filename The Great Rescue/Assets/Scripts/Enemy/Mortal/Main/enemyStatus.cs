using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStatus : MonoBehaviour
{
    public GameObject deathAnimation;
    public float healthPoints;
    public GameObject healPowerUp;
    public GameObject dmgPowerUp;
    public GameObject bloodEffect;
    int rndNmbr;
    const float m_dropChance = 1f / 1f; // 50% chance, change to 1f / 10f for 10% chance etc.. .. .. . . .. . 
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
        PowerupBar.power += 1;
        //drop power up
        if (Random.Range(0f, 1f) <= m_dropChance)
        {
            if(Random.Range(0f, 10f) <= 5f)
            {
                healPowerUp = (GameObject)Instantiate(healPowerUp, gameObject.transform.position, Quaternion.identity);

            }
            else
            {
                dmgPowerUp = (GameObject)Instantiate(dmgPowerUp, gameObject.transform.position, Quaternion.identity);
            }
        }

    }

    

    //Damage methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            healthPoints = ApplyDamage(healthPoints, collision.GetComponent<BulletMoverPlayer>().damage);
            deathCheck();
        }
            

        else if (collision.gameObject.tag == "PlayerSword")
        {

            Debug.Log("Shot hit!");
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
