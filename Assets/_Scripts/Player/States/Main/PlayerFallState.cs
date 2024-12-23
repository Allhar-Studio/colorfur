using UnityEngine;

public class PlayerFallState : PlayerState
{
    private bool hasJumped = false;
    private bool wasGrounded = false;
    private bool jumpedEarly = false;
    private float jumpEarlyTimer;

    public PlayerFallState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        jumpedEarly = false;

        if (parameters != null && parameters.Value.WasGrounded)
            wasGrounded = true;

        if (PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnTakeDamage.AddListener(TakeDamage);
    }

    public override void Exit()
    {
        base.Exit();

        wasGrounded = false;
        jumpedEarly = false;

        Player.SetGravity(Player.Data.normalGravity);

        if (PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnTakeDamage.RemoveListener(TakeDamage);
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        Player.SetVelocity(InputHandler.Instance.Move().x * Player.Data.airMoveSpeed, Player.Rb2d.velocity.y);

        if (!InputHandler.Instance.IsJumping() && Player.Rb2d.velocity.y > 0.01f)
        {
            Player.SetVelocity(Player.Rb2d.velocity.x, Player.Rb2d.velocity.y * Player.Data.fallMultiplier);
        }

        if (Player.IsGrounded && Player.Rb2d.velocity.y < 0.01f)
        {
            _stateMachine.ChangeState(Player.LandState, new StateParameters(jumpedEarly: jumpedEarly));
        }

        if (Player.Rb2d.velocity.y < 0.01f)
        {
            Player.SetGravity(Player.Data.fallGravity);
        }
        else
        {
            Player.SetGravity(Player.Data.normalGravity);
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        Player.CheckIfShouldFlip();

        if (wasGrounded && Time.time > StateEnterTime + Player.Data.coyoteTime)
        {
            wasGrounded = false;
        }

        if (jumpedEarly && Time.time > jumpEarlyTimer + Player.Data.coyoteTime)
        {
            jumpedEarly = false;
        }

        if (InputHandler.Instance.Jump() && wasGrounded && Player.CanMove)
        {
            _stateMachine.ChangeState(Player.JumpState);
        }
        else if (InputHandler.Instance.Jump() && !hasJumped && Player.Data.hasDoubleJump && Player.CanMove)
        {
            hasJumped = true;
            _stateMachine.ChangeState(Player.JumpState, new StateParameters(doubleJump: true));
        }
        
        if (InputHandler.Instance.Jump() && Player.CanMove)
        {
            jumpEarlyTimer = Time.time;
            jumpedEarly = true;
        }

        if (InputHandler.Instance.Dash() && Player.DashState.CanDash())
        {
            _stateMachine.ChangeState(Player.DashState);
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

    public void ResetFallState() => hasJumped = false;
}
