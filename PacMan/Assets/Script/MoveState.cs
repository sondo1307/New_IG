using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State<Entity>
{
    public float speed;
    public MoveState(Entity entity, float speed) : base(entity)
    {
        this.speed = speed;
    }

    public override void DoCkeck()
    {
        base.DoCkeck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {

        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        ABC();
    }
    private void ABC()
    {

    }
}
