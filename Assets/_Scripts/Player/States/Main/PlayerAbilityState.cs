using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool IsAbilityDone { get; private set; }

    public PlayerAbilityState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        IsAbilityDone = false;

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

        if (IsAbilityDone)
        {
            if (Player.IsGrounded && Player.Rb2d.velocity.y < 0.01f)
            {
                _stateMachine.ChangeState(Player.IdleState);
            }
            else
            {
                _stateMachine.ChangeState(Player.FallState);
            }
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    protected void FinishAbility()
    {
        IsAbilityDone = true;
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
