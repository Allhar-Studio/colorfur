using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Player Data", fileName = "newPlayerData")]
public class PlayerData : CharacterData
{
    [Header("------------------------------Movement------------------------------")]
    [Space]
    public float speed = 5f;
    public float airMoveSpeed = 2f;
    public float canMoveDelay = 2f;

    [Header("------------------------------Jump------------------------------")]
    [Space]
    public float jumpForce = 20f;
    public float jumpTime = 0.3f;
    public float fallMultiplier = 0.5f;
    public float coyoteTime = 0.2f;

    [Header("------------------------------Dash------------------------------")]
    [Space]
    public float dashSpeed = 10f;
    public float dashTime = 0.2f;
    public Vector2 dashCamShakeForce = Vector2.zero;

    [Header("------------------------------Damage------------------------------")]
    [Space]
    [Range(0, 10)]
    public int maxLives = 6;
    public float damageTime = 0.2f;
    public float invencibleTime = 1f;
    public Vector2 knockBackSpeed = Vector2.zero;
    public Vector2 knockBackCamShakeForce = Vector2.zero;

    [Header("------------------------------Phisycs------------------------------")]
    [Space]
    [Range(0, 10)]
    public float normalGravity = 2f;
    [Range(0, 10)]
    public float fallGravity = 4;

    [Header("------------------------------Restart------------------------------")]
    [Space]
    public float restartTime = 2f;

    [Header("------------------------------Abilities------------------------------")]
    [Space]
    public bool hasDoubleJump = false;
    public bool hasDash = false;
}
