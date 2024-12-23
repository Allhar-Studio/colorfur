using DG.Tweening;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    private Vector2 _damagerPos;

    public PlayerHurtState(Player character, StateMachine stateMachine, string animParam) : base(character, stateMachine, animParam)
    {
    }

    public override void Enter(StateParameters? parameters = null)
    {
        base.Enter();

        if (parameters != null)
            _damagerPos = parameters.Value.DamagerPos;

        Player.SetVelocity(0f, 0f);

        Player.SetGravity(0f);

        SetKnockBackVelocity();

        Player.Feedbacks.DeathFeedback.PlayFeedbacks();

        Player.SetVelocity(0f, 0f);

        EventManager.Instance.TriggerReloadLevelEvent();

        EventManager.Instance.TriggerCameraShakeEvent(Player.Data.knockBackCamShakeForce.x, Player.Data.knockBackCamShakeForce.y, 0.2f);
    }

    public override void Exit()
    {
        base.Exit();

        Player.SetVelocity(0f, 0f);
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        //SetKnockBackVelocity();

        /*if (isHurt && Time.time > StateEnterTime + Player.Data.damageTime)
        {
            isHurt = false;
            FinishHurtState();
        }*/
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    private void SetKnockBackVelocity()
    {
        var horizontalDir = Player.transform.position.x < _damagerPos.x ? -1 : 1;
        var verticalDir = Player.transform.position.y < _damagerPos.y ? -1 : 1;
        Player.SetVelocity(Player.Data.knockBackSpeed.x * horizontalDir, Player.Data.knockBackSpeed.y * verticalDir);
    }
}
