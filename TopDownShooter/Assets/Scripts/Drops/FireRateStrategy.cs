using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateStrategy : IDropStrategy
{
    public float fireRateTime = 10f;
    public float GetPowerUp()
    {
        return fireRateTime;
    }
}
