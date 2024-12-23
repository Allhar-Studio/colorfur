using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private bool isJumping = false;

    public PlayerJumpState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();
        isJumping = true;

        if (parameters != null && parameters.Value.DoubleJump)
        {
            Player.Animator.SetTrigger(Player.AnimParams.doubleJump);
            Player.Feedbacks.DoubleJumpFeedback?.PlayFeedbacks();
        } else
        {
            if (Player.Feedbacks.JumpFeedback != null && Player.Feedbacks.JumpFeedback.IsPlaying)
                Player.Feedbacks.JumpFeedback.StopFeedbacks();

            Player.Feedbacks.JumpFeedback?.PlayFeedbacks();
        }
    }

    public override void Exit()
    {
        base.Exit();

        isJumping = false;

        Player.Animator.ResetTrigger(Player.AnimParams.doubleJump);
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        Player.SetVelocity(InputHandler.Instance.Move().x * Player.Data.airMoveSpeed, Player.Data.jumpForce);

        if (isJumping && Time.time > StateEnterTime + Player.Data.jumpTime)
        {
            isJumping = false;
            FinishAbility();
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        Player.CheckIfShouldFlip();

        if (InputHandler.Instance.Dash() && Player.DashState.CanDash())
        {
            _stateMachine.ChangeState(Player.DashState);
        }
    }
}
