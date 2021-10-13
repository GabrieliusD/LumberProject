using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{

    public delegate void StartMoveEvent(Vector2 direction);
    public event StartMoveEvent OnStartMove;

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
    }

    void Update()
    {
        
    }

    void StartMove(InputAction.CallbackContext context)
    {
        
    }

    public Vector2 GetMoveValue()
    {
        return playerControls.Land.Move.ReadValue<Vector2>();
    }
}
