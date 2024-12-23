using DG.Tweening;
using UnityEngine;
using UnityEngine.U2D.Animation;
public class Player : Singleton<Player>, IDamageable
{
    //Properties
    public bool IsGrounded { get { return isGrounded; } }
    public bool IsFacingRight { get { return isFacingRight; } }
    public bool IsHurt { get { return isHurt; } }
    public bool CanMove { get { return canMove; } }
    public int Lives { get { return lives; } }

    public PlayerData Data { get { return data; } }
    public Rigidbody2D Rb2d { get { return rb2d; } }
    public Animator Animator { get { return animator; } }
    public PlayerAnimParameters AnimParams { get { return animParameters; } }

    [Header("States")]
    public StateMachine stateMachine;

    [Header("Game Objects")]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator animator;
    [SerializeField] PlayerData data;
    [SerializeField] PlayerAnimParameters animParameters;

    [Header("Grounded Check")]
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("Life")]
    private int lives;

    [Header("Booleans")]
    private bool isFacingRight = true;
    private bool isHurt = false;
    private bool canMove = false;
    private bool isGrounded = false;

    [Header("Effects")]
    public GameObject dashTrail;
    [SerializeField] PlayerFeedBacks feedbacks;
    public PlayerFeedBacks Feedbacks { get { return feedbacks; } }

    [Header("Others")]
    Vector2 currentVelocity = Vector2.zero;
    private float hurtTime;

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }
    public PlayerRestartState RestarState { get; private set; }

    public override void Awake()
    {
        base.Awake();

        stateMachine = new StateMachine();

        IdleState = new PlayerIdleState(this, stateMachine, AnimParams.idle);
        MoveState = new PlayerMoveState(this, stateMachine, AnimParams.walk);
        JumpState = new PlayerJumpState(this, stateMachine, AnimParams.air);
        FallState = new PlayerFallState(this, stateMachine, AnimParams.air);
        LandState = new PlayerLandState(this, stateMachine, AnimParams.land);
        DashState = new PlayerDashState(this, stateMachine, AnimParams.dash);
        HurtState = new PlayerHurtState(this, stateMachine, AnimParams.hurt);
        RestarState = new PlayerRestartState(this, stateMachine, AnimParams.restart);
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        lives = Data.maxLives;
        PlayerEvents.Instance.TriggerChangeHealthEvent(Lives);

        Rb2d.velocity = Vector2.zero;

        DOVirtual.DelayedCall(Data.canMoveDelay, () => { canMove = true; }, false);

        stateMachine?.Initialize(IdleState);
    }

    private void Update()
    {
        stateMachine.Update();

        Animator.SetFloat(AnimParams.verticalAxis, Rb2d.velocity.y);

        if(LevelManager.Instance.IsChangingScene && canMove)
            canMove = false;

        if (isHurt && Time.time > hurtTime + Data.damageTime)
            isHurt = false;
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();

        isGrounded = CheckIfIsGrounded();
    }

    public void SetGravity(float newGravity)
    {
        Rb2d.gravityScale = newGravity;
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        currentVelocity.Set(xVelocity, yVelocity);
        Rb2d.velocity = currentVelocity;
    }

    public void SetDashEffects(bool enable)
    {
        if(dashTrail != null)
            dashTrail.SetActive(enable);
    }

    private bool CheckIfIsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void CheckIfShouldFlip()
    {
        if ((InputHandler.Instance.Move().x > 0 && !isFacingRight) || (InputHandler.Instance.Move().x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            var newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            feedbacks.ChangeFeedbackDirection(isFacingRight);
        }
    }

    public void TakeDamage(int damage, Vector2 damagerPos, DamagerType damagerType)
    {
        if (isHurt)
            return;

        isHurt = true;
        lives -= damage;
        PlayerEvents.Instance.TriggerDamageEvent(damagerPos, damagerType);
        PlayerEvents.Instance.TriggerChangeHealthEvent(Lives);
        hurtTime = Time.time;
        //DOVirtual.DelayedCall(Data.invencibleTime, () => { isHurt = false; }, false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
