using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
    public float damage;

    private void Update()
    {
        if (gameObject.transform.lossyScale.x == 0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }

        else
            GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
