using UnityEngine;

public abstract class State
{    
    protected StateMachine stateMachine;

    protected float timeTimer;

    protected State( StateMachine stateMachine)
    {        
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {        
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void PhysicUpdate() 
    {
    }
    public virtual void Exit()
    {
    }

    /// <summary>
    /// Обратный таймер (Reverse timer)
    /// </summary>
    /// <returns></returns>
    protected bool Timer()
    {
        if (timeTimer <= 0)
            return true;
        timeTimer -= Time.deltaTime;
        return false;
    }
}