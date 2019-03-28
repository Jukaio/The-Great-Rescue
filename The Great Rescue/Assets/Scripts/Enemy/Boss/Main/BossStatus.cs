using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStatus : MonoBehaviour
{
    public float MaxHP;
    public GameObject blood;
    public float currentHP; /*{ get; private set; }*/
    
    void Awake()
    {
        currentHP = MaxHP;
    }

    
    void Update()
    {
        if(currentHP <= 0)
        {
            SceneManager.LoadScene(5);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(blood, gameObject.transform.position, Quaternion.identity);

        if (collision.tag == "PlayerBullet")
            currentHP -= collision.GetComponent<BulletMoverPlayer>().damage;
        if (collision.tag == "PlayerSword")
            currentHP -= collision.GetComponent<swordAttack>().damage;
    }
}
