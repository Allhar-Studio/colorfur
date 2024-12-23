using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRestartState : PlayerAbilityState
{
    private bool isRestartingScene = false;

    public PlayerRestartState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter(parameters);

        Player.SetVelocity(0f, 0f);

        Player.Feedbacks.ReloadFeedback.PlayFeedbacks();
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

        if (Time.time > StateEnterTime + Player.Data.restartTime && !isRestartingScene)
        {
            isRestartingScene = true;
            Player.Feedbacks.ReloadFeedback.StopFeedbacks();
            _stateMachine.ChangeState(Player.HurtState);
        }
        else if (!InputHandler.Instance.IsRestarting() && !isRestartingScene && !IsExittingSate)
        {
            Player.Feedbacks.ReloadFeedback.StopFeedbacks();
            FinishAbility();
        }
    }
}
