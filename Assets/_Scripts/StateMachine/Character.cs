using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody2D Rb2d;

    [SerializeField] protected CharacterData data;
    [SerializeField] protected CharacterAnimParams animParameters;
}
