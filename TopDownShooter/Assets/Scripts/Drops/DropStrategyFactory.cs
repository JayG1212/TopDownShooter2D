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
            case "InvincibilityDrop":
                strategy = new InvincibilityStrategy();
                break;
            default:
                strategy = new HpStrategy();
                break;
        }
        return strategy;
    }

}
