using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DropStrategyFactory
{
    public static IDropStrategy GetStrategy(string aPowerUpTag)
    {
        IDropStrategy strategy = null;

        switch (aPowerUpTag)
        {
            case "HpDrop":
                strategy = new HpStrategy();
                break;
            case "SpeedDrop":
                strategy = new SpeedStrategy();
                break;
            case "FireRateDrop":
                strategy = new FireRateStrategy();
                break;
          
        }
        return strategy;
    }

}
