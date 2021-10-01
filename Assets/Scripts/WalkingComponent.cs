using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingComponent : MonoBehaviour
{
    public LayerMask layer;
    public float WalkingSpeed;
    public float Gravity = -9.81f;

    public float groundedDistance = 0.4f;
    public Transform legs;

    bool isGrounded;
    Vector3 GravityForce;
    Rigidbody RigBody;
    CharacterController characterController;
    CameraController cameraController;
    Vector3 characterLookDir;
    // Start is called before the first frame update
    void Start()
    {
        RigBody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        cameraController = GetComponent<CameraController>();
    }

    

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        //Debug.Log(isGrounded);
        WalkDirection();
        if(isGrounded && GravityForce.y < 0)
        {
            
            GravityForce.y = -2f;
        }

        ApplyGravity();
    }

    void WalkDirection()
    {
        Vector3 cameraForwardDir = cameraController.GetCamera().transform.forward;
        Vector3 cameraRightDir = cameraController.GetCamera().transform.right;
        Vector3 moveDir = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
            moveDir += cameraForwardDir * WalkingSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            moveDir += cameraForwardDir * -WalkingSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            moveDir += cameraRightDir * -WalkingSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            moveDir += cameraRightDir * WalkingSpeed * Time.deltaTime;
        if(moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir.normalized);
            characterController.Move(moveDir);
        }
    }

    void ApplyGravity()
    {
        GravityForce.y += Gravity * Time.deltaTime;
        characterController.Move(GravityForce*Time.deltaTime);
    }

    void CheckIfGrounded()
    {  
        //Physics.Raycast(legs.position, Vector3.down, groundedDistance);
        if(Physics.CheckSphere(legs.position,groundedDistance, layer))
        {
            isGrounded = true;
        } else isGrounded = false;
    }
}
