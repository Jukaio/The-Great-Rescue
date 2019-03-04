using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image cooldown;
    public float waitTime = 10;
    public static bool coolingDown;
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
        if (coolingDown == true)
        {
            Debug.Log("REACHED");
            cooldown.color = Color.green;
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            if(cooldown.fillAmount <= 0)
            {
                coolingDown = false;
            }
        }
        else if(!coolingDown)
        {
                cooldown.fillAmount = 1.0f;
                cooldown.color = Color.gray;
            
        }
    }
   }

