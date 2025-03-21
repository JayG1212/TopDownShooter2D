using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyStateMachine
{
    public ChaseState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        enemy.animator.SetTrigger("Chase"); // Play chase animation
    }

    public override void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);

        if (distance < enemy.attackRange)
        {
            enemy.ChangeState(new AttackState(enemy));
        }
        else
        {
            enemy.MoveTowardsPlayer();
        }
    }

}
