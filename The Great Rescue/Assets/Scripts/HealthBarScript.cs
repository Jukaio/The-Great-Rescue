using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 100f;
    public static float health; 
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //HealthbarScript.health -= "value" makes the bar go down we might want some other way of doing this. But this is how to make it go down for now
        healthBar.fillAmount = health / maxHealth;
    }
}
