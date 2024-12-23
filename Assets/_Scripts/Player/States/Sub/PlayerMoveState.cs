using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    private Vector2 moveInput = Vector2.zero;

    public PlayerMoveState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Checks()
    {
        base.Checks();
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        Player.Feedbacks.WalkFeedback.PlayFeedbacks();
    }

    public override void Exit()
    {
        base.Exit();

        Player.Feedbacks.WalkFeedback.StopFeedbacks();
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        Player.SetVelocity(Player.Data.speed * InputHandler.Instance.Move().x, Player.Rb2d.velocity.y);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        moveInput = InputHandler.Instance.Move();

        Player.CheckIfShouldFlip();

        if ((moveInput.x == 0 || InputHandler.Instance.IsLooking()) && !IsExittingSate)
        {
            _stateMachine.ChangeState(Player.IdleState);
        }
    }
}
