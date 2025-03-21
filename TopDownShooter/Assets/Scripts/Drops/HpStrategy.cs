using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpStrategy : IDropStrategy
{
    public float hp = 5;
   public float GetPowerUp()
    {
        return hp;
    } 
}
