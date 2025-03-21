using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyStateMachine
{
    public IdleState(Enemy enemy) : base(enemy) { }

    public override void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);

        if (distance < enemy.chaseRange)
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }
}
