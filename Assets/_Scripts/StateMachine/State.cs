using UnityEngine;

public class State
{
    protected Character _character;
    protected StateMachine _stateMachine;
    protected string _animParam;

    protected bool IsExittingSate { get; private set; }
    protected float StateEnterTime { get; private set; }

    public State(Character character, StateMachine stateMachine, string animParam)
    {
        _character = character;
        _stateMachine = stateMachine;
        _animParam = animParam;
    }

    public virtual void Enter(StateParameters? parameters = null)
    {
        if (_character.Animator != null)
            _character.Animator.SetBool(_animParam, true);
        IsExittingSate = false;
        StateEnterTime = Time.time;
        /*Debug.Log(this);
        Debug.Log(parameters);*/
    }

    public virtual void Exit()
    {
        IsExittingSate = true;
        if (_character.Animator != null)
            _character.Animator.SetBool(_animParam, false);
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
