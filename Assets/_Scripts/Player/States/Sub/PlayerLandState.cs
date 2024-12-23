using UnityEngine;

public class PlayerLandState : PlayerGroundState
{
    public PlayerLandState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter(parameters);

        Player.SetVelocity(Player.Rb2d.velocity.x, 0f);

        Player.Feedbacks.LandFeedback?.PlayFeedbacks();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Time.time > StateEnterTime + 0.1f && !IsExittingSate)
        {
            if (InputHandler.Instance.Move().x != 0 && Player.CanMove)
            {
                _stateMachine.ChangeState(Player.MoveState);
            }
            else
            {
                _stateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}
