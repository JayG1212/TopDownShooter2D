using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityStrategy : IDropStrategy
{
    public float invincibilityTime = 10f;
    public float GetPowerUp()
    {
        return invincibilityTime;
    }
}
