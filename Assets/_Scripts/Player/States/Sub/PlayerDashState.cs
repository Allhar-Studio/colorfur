using UnityEngine;
using DG.Tweening;

public class PlayerDashState : PlayerAbilityState
{
    private int direction;
    private bool canDash;
    private bool isDashing = false;

    public PlayerDashState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        canDash = false;
        isDashing = true;
        direction = Player.IsFacingRight ? 1 : -1;
        Player.SetGravity(0f);
        Player.SetDashEffects(true);
        Player.Feedbacks.DashFeedback?.PlayFeedbacks();
        PlayerEvents.Instance.TriggerDashEvent(Player.Data.dashTime);
        EventManager.Instance.TriggerCameraShakeEvent(Player.Data.dashCamShakeForce.x, Player.Data.dashCamShakeForce.y, Player.Data.dashTime);
    }

    public override void Exit()
    {
        base.Exit();

        Player.SetDashEffects(false);
        Player.SetVelocity(0f, 0f);
        Player.SetGravity(Player.Data.normalGravity);
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        if (isDashing)
            Player.SetVelocity(Player.Data.dashSpeed * direction, 0f);

        if (isDashing && Time.time > StateEnterTime + Player.Data.dashTime)
        {
            isDashing = false;
            FinishAbility();
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public bool CanDash() => Player.Data.hasDash && canDash && Player.CanMove;
    public void RestDash() => canDash = true;
}
