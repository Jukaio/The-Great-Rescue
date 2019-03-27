using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStatus : MonoBehaviour
{
    public float MaxHP;
    public float currentHP; /*{ get; private set; }*/
    
    void Awake()
    {
        currentHP = MaxHP;
    }

    
    void Update()
    {
        if(currentHP <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
            currentHP -= collision.GetComponent<BulletMoverPlayer>().damage;
        if (collision.tag == "PlayerSword")
            currentHP -= collision.GetComponent<swordAttack>().damage;
    }
}
