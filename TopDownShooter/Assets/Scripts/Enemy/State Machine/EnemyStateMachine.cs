// Written By Jay Gunderson
// 03/19/2025
public abstract class EnemyStateMachine
{
    protected Enemy enemy;

    public EnemyStateMachine(Enemy enemy) => this.enemy = enemy;

    public virtual void Enter() { }   // Called when entering this state
    public virtual void Update() { }  // Called every frame
    public virtual void Exit() { }    // Called when exiting this state
}

