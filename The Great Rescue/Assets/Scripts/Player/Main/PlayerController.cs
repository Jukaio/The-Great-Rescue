using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


//public enum myEnum // your custom enumeration
//{
//    Rigidbody,
//    CharacterController,
//};



public class PlayerController : MonoBehaviour


{
    public GameObject GameSpawner;
    public List<GameObject> enemies;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    playerStatus playerStatus;


    public GameObject meleeWeapon;
    public GameObject swordSound;
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

    public float amountOfLines;
    private float highestLineIndex;
    private float lowestLineIndex;

  

    private Vector3 travelVector;
    private float originY;
    public float moveSpeed;

    Vector3 oldPos;
    public float direction;

    void Start()
    {
        originY = transform.position.y;
        meleeAttackCooldownHolder = meleeAttackCooldown;
        climaxAnimationSwordHolder = climaxAnimationSword;
        originY = transform.position.y;

        highestLineIndex = (amountOfLines - 1) / 2;
        lowestLineIndex = highestLineIndex - (amountOfLines - 1);

        playerStatus = GetComponent<playerStatus>();



        if (amountOfLines % 2 == 0) //Check if odd or even -> If even adjust Index
        {
            highestLineIndex = (float)Math.Floor(highestLineIndex);
            lowestLineIndex = (float)Math.Floor(lowestLineIndex);
        }

    }

    void FixedUpdate()
    {
        enemies = GameSpawner.GetComponent<GameController>().enemies;

        if (Input.GetKey("b"))
            {
                Destroy(enemies[1]);
            }

        
        //Attacks
            if (!isInMeleeAttack && !goesOutOfMeleeAttack) //Attacks
        {
            if (GetComponent<MeleeAttack>().IsEnemyInMelee())
            {
                if (Input.GetKey("space")
                && Time.time > nextFire
                && playerStatus.getCanShoot())
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
                    Instantiate(swordSound, gameObject.transform.position, Quaternion.identity);
                    meleeWeapon.transform.localScale = new Vector3(10f * Time.deltaTime, 1f, 1f); //frame time = 0.02 secs
                    isInMeleeAttack = true;

                    meleeAttackCooldownHolder = meleeAttackCooldown;
                }
            }
        }

        else if (isInMeleeAttack && !goesOutOfMeleeAttack)
        {
            meleeWeapon.transform.localScale = new Vector3(meleeWeapon.transform.localScale.x + (10f * Time.deltaTime), 1f, 1f);
        }

        else if (goesOutOfMeleeAttack && isInMeleeAttack && !isSwordInClimax)
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

        else if (meleeWeapon.transform.localScale.x <= 0)
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
        //Line Movement
        if (Input.GetKey(KeyCode.W) && GetComponent<CheckUpAndDown>().isUpBlocked())
        {
            oldPos = transform.position;
            travelVector = new Vector3(transform.position.x, originY + (moveDistance * highestLineIndex), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
            direction = transform.position.y - oldPos.y;
        }

        else if (Input.GetKey(KeyCode.S) && GetComponent<CheckUpAndDown>().isDownBlocked())
        {
            oldPos = transform.position;
            travelVector = new Vector3(transform.position.x, originY + (moveDistance * lowestLineIndex), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
            direction = transform.position.y - oldPos.y;
        }

        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false /*&& gameObject.transform.position.y <= moveDistance * highestLineIndex*/)
        {
            AdjustPosition();
        }

        if (Input.GetKey(KeyCode.F) && playerStatus.specialBar == playerStatus.maxSpecialBar)
        {
            playerStatus.specialBar = 0;

            foreach(GameObject enemy in enemies)
            {
                if(enemy.tag == "Enemy")
                    enemy.GetComponent<enemyStatus>().healthPoints -= 50;
            }
            Debug.Log("3");
        }

        else if (Input.GetKey(KeyCode.F) && playerStatus.specialBar >= (playerStatus.maxSpecialBar / 3) * 2)
        {
            playerStatus.specialBar = 0;

            foreach (GameObject enemy in enemies)
            {
                if (enemy.tag == "Enemy" && enemy.transform.position.x <= GetComponent<MeleeAttack>().range)
                {
                    enemy.GetComponent<enemyStatus>().healthPoints -= 50;
                }
            }
            Debug.Log("2");
        }

        if (Input.GetKey(KeyCode.F) && playerStatus.specialBar >= (playerStatus.maxSpecialBar / 3))
        {
            playerStatus.specialBar = 0;

            foreach (GameObject enemy in enemies)
            {
                if (enemy.tag == "Enemy" && Mathf.Round(enemy.transform.position.y) == Mathf.Round(gameObject.transform.position.y) - 1)
                {
                    enemy.GetComponent<enemyStatus>().healthPoints -= 50;
                }
            }
            Debug.Log("1");
        }
    }

    private void AdjustPosition() //Method for adjusting the player position
    {
        for (float i = moveDistance * highestLineIndex + originY; i >= moveDistance * lowestLineIndex; i -= moveDistance)
        {
            if (direction > 0)
            {
                if ((transform.position.y >  i &&
                    transform.position.y <  i + moveDistance &&
                    transform.position.y !=  i))
                {
                    travelVector = new Vector3(transform.position.x,  i + moveDistance, transform.position.z);
                    Debug.Log(travelVector);
                    transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
                }
            }
            else if (direction < 0)
            {
                if ((transform.position.y <  i &&
                    transform.position.y >  i - moveDistance &&
                    transform.position.y !=  i))
                {
                    Debug.Log("Yo");
                    travelVector = new Vector3(transform.position.x,  i - moveDistance, transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
                }
            }
        }
    }

    public float returnHighestLine()
    {
        return highestLineIndex;
    }

    public float returnLowestLine()
    {
        return lowestLineIndex;
    }

    IEnumerator wait() //method for animation etc during sword
    {
        yield return new WaitForSeconds(0.5f);
    }
}