using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    #region Events

    
    public delegate void StartMoveEvent(Vector2 direction);
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    public event StartMoveEvent OnStartMove;
    #endregion

    private PlayerControls playerControls;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    { 
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Start()
    {
        playerControls.Land.Move.performed += ctx => StartMove(ctx);
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);

    }

    void StartMove(InputAction.CallbackContext context)
    {
        
    }

    public Vector2 GetMoveValue()
    {
        return playerControls.Land.Move.ReadValue<Vector2>();
    }

    void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if(OnStartTouch != null) OnStartTouch(ScreenToWorld(Camera.main,playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if(OnEndTouch != null) OnEndTouch(ScreenToWorld(Camera.main, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        Debug.Log("Raw Pos: " + position);
        Debug.Log("To World Pos: " + camera.ScreenToWorldPoint(position));
        return camera.ScreenToWorldPoint(position);
        
    }

    public Vector2 PrimaryPosition()
    {
        return ScreenToWorld(Camera.main, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

    public Vector2 PrimaryGetDelta()
    {
        return playerControls.Touch.PrimaryMovement.ReadValue<Vector2>();
    }

    public PlayerControls GetPlayerControls()
    {
        return playerControls;
    }

    public bool PressedInteract()
    {
        return playerControls.Touch.Interact.triggered;
    }
}
