using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusDamagePowerUp : MonoBehaviour
{
    public float duration;
    public float multiplier;
    public float speed;
    public GameObject sound;



    void Update()
    {
        Vector2 movement = new Vector2(-1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(sound, gameObject.transform.position, Quaternion.identity);

            collision.gameObject.GetComponent<playerStatus>().damageBuff = true;
            collision.gameObject.GetComponent<playerStatus>().damageBuffDuration = duration;
            collision.gameObject.GetComponent<playerStatus>().damageMultiplier = multiplier;
            Cooldown.coolingDown = true;
            Destroy(gameObject);
        }
    }
}
