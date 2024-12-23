using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        Player.SetVelocity(0f, Player.Rb2d.velocity.y);
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

        Player.CheckIfShouldFlip();

        if (InputHandler.Instance.Move().x != 0 && !IsExittingSate && Player.CanMove && !InputHandler.Instance.IsLooking())
        {
            _stateMachine.ChangeState(Player.MoveState);
        }
    }
}
