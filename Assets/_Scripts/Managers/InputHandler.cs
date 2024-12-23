using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{
    [SerializeField] PlayerInput playerInput;

    private bool IsHoldingJump;
    private bool IsHoldingShoot;
    private bool IsHoldingRestart;
    private bool IsHoldingLook;

    public string CurrentControlScheme { get; private set; }

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction dashAction;
    private InputAction shootAction;
    private InputAction restartAction;
    private InputAction lookAction;
    private InputAction pauseAction;
    private InputAction nextAction;
    private InputAction previousAction;

    public override void Awake()
    {
        base.Awake();

        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        dashAction = playerInput.actions["Dash"];
        shootAction = playerInput.actions["Shoot"];
        restartAction = playerInput.actions["Restart"];
        lookAction = playerInput.actions["View"];
        pauseAction = playerInput.actions["Pause"];
        nextAction = playerInput.actions["Next"];
        previousAction = playerInput.actions["Prev"];

        //Cursor.lockState = CursorLockMode.Locked;

        CurrentControlScheme = playerInput.currentControlScheme;
    }

    private void OnEnable()
    {
        jumpAction.started += ctx => IsHoldingJump = true;
        jumpAction.canceled += ctx => IsHoldingJump = false;

        shootAction.started += ctx => IsHoldingShoot = true;
        shootAction.canceled += ctx => IsHoldingShoot = false;

        restartAction.started += ctx => IsHoldingRestart = true;
        restartAction.canceled += ctx => IsHoldingRestart = false;

        lookAction.started += ctx => IsHoldingLook = true;
        lookAction.canceled += ctx => IsHoldingLook = false;
    }

    private void OnDisable()
    {
        jumpAction.started -= ctx => IsHoldingJump = true;
        jumpAction.canceled -= ctx => IsHoldingJump = false;

        shootAction.started -= ctx => IsHoldingShoot = true;
        shootAction.canceled -= ctx => IsHoldingShoot = false;

        restartAction.started -= ctx => IsHoldingRestart = true;
        restartAction.canceled -= ctx => IsHoldingRestart = false;

        lookAction.started -= ctx => IsHoldingLook = true;
        lookAction.canceled -= ctx => IsHoldingLook = false;
    }


    private void Update()
    {
        ListenForDeviceChanges();
        //print(CurrentControlScheme);
    }

    private void ListenForDeviceChanges()
    {
        if (playerInput.currentControlScheme != CurrentControlScheme)
        {
            ChangeControlScheme(playerInput.currentControlScheme);
        }
    }

    private void ChangeControlScheme(string newControlSchema)
    {
        CurrentControlScheme = newControlSchema;
    }

    public Vector2 Move()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public bool Jump()
    {
        return jumpAction.triggered;
    }

    public bool IsJumping()
    {
        return IsHoldingJump;
    }

    public bool Dash()
    {
        return dashAction.triggered;
    }

    public bool IsShooting()
    {
        return IsHoldingShoot;
    }

    public bool IsRestarting()
    {
        return IsHoldingRestart;
    }

    public bool IsLooking()
    {
        return IsHoldingLook;
    }

    public bool Pause()
    {
        return pauseAction.triggered;
    }

    public bool Next()
    {
        return nextAction.triggered;
    }

    public bool Prev()
    {
        return previousAction.triggered;
    }

    public void ChangeActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }
}
