using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T>
{
    protected T m_Enity;
    public State(T entity){
        m_Enity = entity;
    }
    public virtual void Enter() {
        DoCkeck();
    }
    public virtual void Exit() { }
    public virtual void LogicUpdate() {
        DoCkeck();
    }
    public virtual void PhysicUpdate() { }
    public virtual void DoCkeck() { }
}
