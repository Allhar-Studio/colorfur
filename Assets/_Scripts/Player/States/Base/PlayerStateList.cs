using UnityEngine;

public class PlayerStateList : MonoBehaviour
{
    public StateMachine stateMachine;

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }
    public PlayerRestartState RestarState { get; private set; }

    public void InstantiateStates(Player character)
    {

        stateMachine = character.stateMachine;

        IdleState = new PlayerIdleState(character, stateMachine, character.AnimParams.idle);
        MoveState = new PlayerMoveState(character, stateMachine, character.AnimParams.walk);
        JumpState = new PlayerJumpState(character, stateMachine, character.AnimParams.air);
        FallState = new PlayerFallState(character, stateMachine, character.AnimParams.air);
        LandState = new PlayerLandState(character, stateMachine, character.AnimParams.land);
        DashState = new PlayerDashState(character, stateMachine, character.AnimParams.dash);
        HurtState = new PlayerHurtState(character, stateMachine, character.AnimParams.hurt);
        RestarState = new PlayerRestartState(character, stateMachine, character.AnimParams.restart);
    }

    public void InitStateMachine()
    {
        stateMachine?.Initialize(IdleState);
    }
}
