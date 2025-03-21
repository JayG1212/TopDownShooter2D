using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyStateMachine
{
    public AttackState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        enemy.animator.SetTrigger("Attack");
    }

    public override void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.player.position);

        if (distance > enemy.attackRange)
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }

}
