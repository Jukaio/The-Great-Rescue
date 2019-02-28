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

    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    private bool moveToPoint = false;
    private Vector3 endPosition;

    public GameObject meleeWeapon;
    public bool isInMeleeAttack = false;
    public bool goesOutOfMeleeAttack = false;

    public float meleeAttackRange;

    public float meleeAttackCooldown;
    public float meleeAttackCooldownHolder;
    public float climaxAnimationSword;
    public float climaxAnimationSwordHolder;
    public bool isSwordInClimax;


    void Start()
    {

        endPosition = transform.position;
        meleeAttackCooldownHolder = meleeAttackCooldown;
        climaxAnimationSwordHolder = climaxAnimationSword;
    }

    void FixedUpdate()
    {
        if (moveToPoint) //Movement
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }

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
        if (endPosition.y <= 3f)
        {
            if (Input.GetKeyDown(KeyCode.W)) //Up
            {
                endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
                moveToPoint = true;
            }
        }
        if (endPosition.y >= -2f)
        {
            if (Input.GetKeyDown(KeyCode.S)) //Down
            {
                endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                moveToPoint = true;
            }
        }

    }

    IEnumerator wait() //method for animation etc during sword
    {
        yield return new WaitForSeconds(0.5f);
    }


}

