using UnityEngine;
public struct StateParameters
{
    [Header("Jump")]
    public bool DoubleJump;
    public bool WasGrounded;
    public bool JumpedEarly;

    [Header("Damage")]
    public Vector2 DamagerPos;

    public StateParameters(bool doubleJump = false, 
                            bool wasGrounded = false, 
                            bool jumpedEarly = false,
                            Vector2 damagerPos = new Vector2())
    {
        DoubleJump = doubleJump;
        WasGrounded = wasGrounded;
        JumpedEarly = jumpedEarly;
        DamagerPos = damagerPos;
    }
}
