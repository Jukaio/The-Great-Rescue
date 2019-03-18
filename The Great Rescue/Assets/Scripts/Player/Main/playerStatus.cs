using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public GameObject hitSound;
    public GameObject deathSound;
    public Animator animator;
    public float healthPoints;
    private bool waitActive;
    private bool canShoot = true;

    public bool damageBuff = false;
    public float damageBuffDuration;
    public float damageMultiplier;

    public float specialBar = 0;
    public float maxSpecialBar;


    void Update()
    {
        //Death check
        if (healthPoints <= 0)
        {
            Instantiate(deathSound, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
        }
            
        gameObject.transform.localScale = new Vector3(1.1f - (gameObject.transform.position.y / 16f), 1.1f - (gameObject.transform.position.y / 16f), 1f);
        

        //Buff data
        damageBuffDuration -= Time.deltaTime;
        if (damageBuffDuration <= 0)
        {
            damageMultiplier = 0;
            damageBuff = false;
            damageBuffDuration = 0;
            
        }

        if(specialBar >= maxSpecialBar)
        {
            specialBar = maxSpecialBar;
        }

    }

    //Damage methods and heal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet"
            || collision.gameObject.tag == "Enemy"
            || collision.gameObject.tag == "Obstacle"
            || collision.gameObject.tag == "BossBullet")
        {
            if (!waitActive)
            {
                healthPoints = ApplyDamage(healthPoints, 1);

                if (collision.gameObject.tag != "Obstacle" && collision.gameObject.tag != "BossBullet" && collision.gameObject.tag != "Boss")
                {
                    Destroy(collision.gameObject);
                }

                HealthBarScript.health -= 10;
                animator.SetBool("isHurt", true); // play the animation of getting hurt
                Instantiate(hitSound, Vector3.zero, Quaternion.identity);

                StartCoroutine(Wait());
               
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            healthPoints = ApplyDamage(healthPoints, 5);
        }

    }

    //method for avoiding damage and not being able to shoot while hurt
    IEnumerator Wait()
    {
        waitActive = true;
        canShoot = false;
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("isHurt", false); // stop the animation if getting hurt
        canShoot = true;
        waitActive = false;
    }

    float ApplyDamage(float healthPoints, float damage)
    {
        return healthPoints - damage;
    }

    public bool getCanShoot()
    {
        return canShoot;
    }
}
