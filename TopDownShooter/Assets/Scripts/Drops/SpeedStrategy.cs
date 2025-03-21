using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStrategy : IDropStrategy
{
    public float speedDuration;
    public float GetPowerUp()
    {
        return 8f;
    }
}
