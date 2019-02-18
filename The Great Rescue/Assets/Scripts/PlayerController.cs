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
    public float healthPoints;
    public Animator animator; 
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public bool damageBuff = false;
    public float damageBuffDuration;
    public float damageMultiplier;


    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    private bool moveToPoint = false;
    private Vector3 endPosition;





    void Start()
    {
        endPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
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


        if (Input.GetKey("space") && Time.time > nextFire)
        {
            //animator.SetBool("isShooting", true);
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        }

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
        if (collision.gameObject.tag == "Enemy")
        {
            healthPoints = ApplyDamage(healthPoints, 1);
            Destroy(collision.gameObject);
            HealthBarScript.health -= 10;
        }

        else if (collision.gameObject.tag == "Heal")
        {
            healthPoints = ApplyDamage(healthPoints, -1);
            Destroy(collision.gameObject);
            HealthBarScript.health += 1;
        }

    //buffs/powerups
        else if (collision.gameObject.tag == "BuffDamage")
        {
            damageBuff = true;
            damageBuffDuration = collision.GetComponent<damageBuffData>().duration;
            damageMultiplier = collision.GetComponent<damageBuffData>().multiplier;
            Destroy(collision.gameObject);
        }

    }

    float ApplyDamage(float health, float damage)
    {
        return health - damage;
    }


}

