using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        Player.FallState.ResetFallState();

        Player.DashState.RestDash();

        if (parameters != null && parameters.Value.JumpedEarly)
            _stateMachine.ChangeState(Player.JumpState);

        if (PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnTakeDamage.AddListener(TakeDamage);
    }

    public override void Exit()
    {
        base.Exit();

        if (PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnTakeDamage.RemoveListener(TakeDamage);
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (InputHandler.Instance.Jump() && Player.CanMove && !InputHandler.Instance.IsLooking())
        {
            _stateMachine.ChangeState(Player.JumpState);
        }

        else if (!Player.IsGrounded && Player.Rb2d.velocity.y < 0.01f && !IsExittingSate)
        {
            _stateMachine.ChangeState(Player.FallState, new StateParameters(wasGrounded: true));
        }

        else if (InputHandler.Instance.Dash() && Player.DashState.CanDash())
        {
            _stateMachine.ChangeState(Player.DashState);
        }

        else if (InputHandler.Instance.IsRestarting() && Player.CanMove)
        {
            _stateMachine.ChangeState(Player.RestarState);
        }
    }

    private void TakeDamage(Vector2 damagerPos, DamagerType damagerType)
    {
        if (Player == null || Player.Animator == null || Player.Rb2d == null)
        {
            if (PlayerEvents.Instance != null)
                PlayerEvents.Instance.OnTakeDamage.RemoveListener(TakeDamage);
            return;
        }

        _stateMachine.ChangeState(Player.HurtState, new StateParameters(damagerPos: damagerPos));
    }
}
