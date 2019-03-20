using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TrapAttack : MonoBehaviour
{
    public GameObject blood;
    Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("trapActivated", true);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
