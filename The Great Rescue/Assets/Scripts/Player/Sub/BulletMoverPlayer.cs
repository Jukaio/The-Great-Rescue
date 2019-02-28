using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoverPlayer : MonoBehaviour
{
    public float speed;
    public float damage;

    void Start()
    {
        if (GameObject.Find("PlayerBody").GetComponent<playerStatus>().damageBuff == true)
        {
            damage *= GameObject.Find("PlayerBody").GetComponent<playerStatus>().damageMultiplier;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);

        if (gameObject.transform.position.x >= 11)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player" && collision.gameObject.layer != 8)
                Destroy(gameObject);
        }
    }
}
