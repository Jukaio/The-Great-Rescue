using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageCalculation : MonoBehaviour
{
    float ApplyDamage(float health, float damage)
    {
        return health - damage;
    }
}
