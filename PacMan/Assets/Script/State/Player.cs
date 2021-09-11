using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public StateMachine<Entity> stateMachine;

    public MoveState moveState;

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicUpdate();
    }
    public void Init()
    {
        stateMachine = new StateMachine<Entity>();
        moveState = new MoveState(this, 10);

        stateMachine.Init(moveState);
        stateMachine.ChangeState(moveState);
    }

}
