using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownDamage : MonoBehaviour
{
    public Image cooldown;
    public float waitTime = 10;
    public static bool dmgCoolingDown;
    bool filledBar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        PowerUpActive();
    }

    public void PowerUpActive()
    {
        if (dmgCoolingDown == true)
        {
            
            cooldown.color = Color.green;
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            if(cooldown.fillAmount <= 0)
            {
                dmgCoolingDown = false;
            }
        }
        else if(!dmgCoolingDown)
        {
                cooldown.fillAmount = 1.0f;
                cooldown.color = Color.gray;
            
        }
    }
   }

