using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public Animator animator;
    public float healthPoints;
    private bool waitActive;
    private bool canShoot = true;

    public bool damageBuff = false;
    public float damageBuffDuration;
    public float damageMultiplier;


    void Update()
    {
        //Death check
        if (healthPoints <= 0)
            Destroy(gameObject);

        //Buff data
        damageBuffDuration -= Time.deltaTime;
        if (damageBuffDuration <= 0)
        {
            damageMultiplier = 0;
            damageBuff = false;
            damageBuffDuration = 0;
            
        }

    }

    //Damage methods and heal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet"
            || collision.gameObject.tag == "Enemy")
        {
            if (!waitActive)
            {
                healthPoints = ApplyDamage(healthPoints, 1);
                Destroy(collision.gameObject);
                HealthBarScript.health -= 10;
                animator.SetBool("isHurt", true); // play the animation of getting hurt
                StartCoroutine(Wait());
            }
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
