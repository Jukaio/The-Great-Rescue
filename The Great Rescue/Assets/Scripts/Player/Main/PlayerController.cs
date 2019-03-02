using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Experimental.UIElements;
using System;


//public enum myEnum // your custom enumeration
//{
//    Rigidbody,
//    CharacterController,
//};



public class PlayerController : MonoBehaviour


{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;




    public GameObject meleeWeapon;
    public bool isInMeleeAttack = false;
    public bool goesOutOfMeleeAttack = false;

    public float meleeAttackRange;
    public float meleeAttackCooldown;
    public float meleeAttackCooldownHolder;
    public float climaxAnimationSword;
    public float climaxAnimationSwordHolder;
    public bool isSwordInClimax;
    [Tooltip("The magnitude of the highest line added to the magnitude of the lowest line. Their sum devided by four. The quotient is the move distance")]
    public float moveDistance;
    private Vector3 travelVector;
    private float originY;
    public float moveSpeed;


    void Start()
    {
        originY = transform.position.y;
        meleeAttackCooldownHolder = meleeAttackCooldown;
        climaxAnimationSwordHolder = climaxAnimationSword;
        originY = transform.position.y;
    }

    void FixedUpdate()
    {
        //Line Movement
        if (Input.GetKey(KeyCode.W))
        {
            travelVector = new Vector3(transform.position.x, originY + (moveDistance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            travelVector = new Vector3(transform.position.x, originY - (moveDistance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == false)
        {
            AdjustPosition();
        }





        //Attacks
            if (!isInMeleeAttack && !goesOutOfMeleeAttack) //Attacks
        {
            if (GetComponent<MeleeAttack>().IsEnemyInMelee())
            {
                if (Input.GetKey("space")
                && Time.time > nextFire
                && GetComponent<playerStatus>().getCanShoot())
                {
                    //animator.SetBool("isShooting", true);

                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }

            else if (GetComponent<MeleeAttack>().IsEnemyInMelee() == false && meleeAttackCooldownHolder <= 0)
            {
                if (Input.GetKey("space"))
                {
                    meleeWeapon.transform.localScale = new Vector3(10f * Time.deltaTime, 1f, 1f); //frame time = 0.02 secs
                    isInMeleeAttack = true;
                    meleeAttackCooldownHolder = meleeAttackCooldown;
                }
            }
        }

        else if(isInMeleeAttack && !goesOutOfMeleeAttack)
        {
            meleeWeapon.transform.localScale = new Vector3(meleeWeapon.transform.localScale. x + (10f * Time.deltaTime), 1f, 1f);
        }

        else if(goesOutOfMeleeAttack && isInMeleeAttack && !isSwordInClimax)
        {
            meleeWeapon.transform.localScale = new Vector3(meleeWeapon.transform.localScale.x - (10f * Time.deltaTime), 1f, 1f);

        }


        if (meleeWeapon.transform.localScale.x >= meleeAttackRange && !isSwordInClimax)
        {
            isInMeleeAttack = true;
            isSwordInClimax = true;

            climaxAnimationSwordHolder = climaxAnimationSword;
            goesOutOfMeleeAttack = true;
            
        }

        else if(meleeWeapon.transform.localScale.x <= 0)
        {
            isInMeleeAttack = false;
            goesOutOfMeleeAttack = false;
            meleeWeapon.transform.localScale = new Vector3(0f, 1f, 1f); //frame time = 0.02 secs
        }

        meleeAttackCooldownHolder -= Time.deltaTime;
        climaxAnimationSwordHolder -= Time.deltaTime;

        if (climaxAnimationSwordHolder <= 0)
            isSwordInClimax = false;

        if (meleeAttackCooldownHolder <= 0)
            meleeAttackCooldownHolder = 0;

        if (climaxAnimationSwordHolder <= 0)
            climaxAnimationSwordHolder = 0;
        
    }

    void Update()
    {
        


    }

    IEnumerator wait() //method for animation etc during sword
    {
        yield return new WaitForSeconds(0.5f);
    }

    private void AdjustPosition()
    {
        if (transform.position.y >= originY + ((moveDistance * 2) - (moveDistance / 2)) &&
            transform.position.y != originY + (moveDistance * 2))
        {
            travelVector = new Vector3(transform.position.x, originY + (moveDistance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y >= originY + ((moveDistance) - (moveDistance / 2)) &&
                transform.position.y < originY + ((moveDistance * 2) - (moveDistance / 2)) &&
                transform.position.y != originY + moveDistance)
        {
            travelVector = new Vector3(transform.position.x, originY + (moveDistance), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y < originY + (moveDistance / 2) &&
                   transform.position.y >= originY - (moveDistance / 2) &&
                   transform.position.y != originY)
        {
            travelVector = new Vector3(transform.position.x, originY, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y < originY - ((moveDistance) - (moveDistance / 2)) &&
                transform.position.y >= originY - ((moveDistance * 2) - (moveDistance / 2)) &&
                transform.position.y != originY - moveDistance)
        {
            travelVector = new Vector3(transform.position.x, originY - (moveDistance), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y < originY - ((moveDistance * 2) - (moveDistance / 2)) &&
            transform.position.y != originY - (moveDistance * 2))
        {
            travelVector = new Vector3(transform.position.x, originY - (moveDistance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
    }

}

