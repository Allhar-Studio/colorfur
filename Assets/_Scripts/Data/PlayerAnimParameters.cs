using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Player Animations Parameters", fileName = "newPlayerAnimationsParametersData")]
public class PlayerAnimParameters : CharacterAnimParams
{
    public string idle = "Idle";
    public string walk = "Walk";
    public string air = "InAir";
    public string dash = "Dash";
    public string land = "Land";
    public string hurt = "Hurt";
    public string restart = "Restart";
    public string verticalAxis = "yFloat";
    public string doubleJump = "DoubleJump";
}
