using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyStateMachine
{
    public DeadState(Enemy enemy) : base(enemy) { }

    public override void Enter()
    {
        enemy.animator.SetTrigger("Dead");
        enemy.GetComponent<Collider2D>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().simulated = false;

        enemy.StartCoroutine(enemy.RemoveZombie());
    }
}
