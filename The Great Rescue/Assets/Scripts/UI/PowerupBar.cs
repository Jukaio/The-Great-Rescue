using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupBar : MonoBehaviour
{
    Image powerBar;
    public float maxPower = 100f;
    public static float power; 
    // Start is called before the first frame update
    void Start()
    {
        powerBar = GetComponent<Image>();
        powerBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.fillAmount = power / 50;
        

    }
}
