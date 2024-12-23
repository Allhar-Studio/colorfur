using UnityEngine;

public class PlayerState
{
    protected StateMachine _stateMachine;
    protected string _animParam;
    protected Player Player;

    protected bool IsExittingSate { get; private set; }
    protected float StateEnterTime { get; private set; }

    public PlayerState(Player character, StateMachine stateMachine, string animParam)
    {
        Player = character;
        _stateMachine = stateMachine;
        _animParam = animParam;
    }

    public virtual void Enter(StateParameters? parameters = null)
    {
        if (Player.Animator != null)
            Player.Animator.SetBool(_animParam, true);
        IsExittingSate = false;
        StateEnterTime = Time.time;
        /*Debug.Log(this);
        Debug.Log(parameters);*/
    }

    public virtual void Exit()
    {
        IsExittingSate = true;
        if (Player.Animator != null)
            Player.Animator.SetBool(_animParam, false);
    }

    public virtual void PhysicsLogic()
    {
        Checks();
    }

    public virtual void UpdateLogic()
    {

    }

    public virtual void Checks() { }
}
