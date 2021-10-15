using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _CameraFollowSpeed;
    public Vector3 CameraPosition;
    public Vector3 CameraLookPosition;
    public Vector3 Rotation;
    Camera mainCamera;
    InputManager inputManager;
    void Start()
    {
        mainCamera = Camera.main;
        inputManager = InputManager.Instance;
        //mainCamera.transform.position = transform.position + CameraPosition;
    }

    void UpdateCamera()
    {
        
    }

    void Update()
    {
        Vector3 currentCameraPos = mainCamera.transform.position;
        Vector3 newCameraPosition = transform.position + CameraPosition;
        Vector3 currentCameraLookPos = transform.position + CameraLookPosition;

        Vector3 pivot = transform.position;

        Vector2 touchDelta = inputManager.PrimaryGetDelta();
        float tempX = touchDelta.x;
        touchDelta.x = touchDelta.y;
        touchDelta.y = tempX;
        Vector3 dir = newCameraPosition - pivot;
        dir = Quaternion.Euler(Rotation * touchDelta) * dir;
        newCameraPosition = dir + pivot;
        CameraPosition = newCameraPosition - transform.position;


        dir = currentCameraLookPos - pivot;
        dir = Quaternion.Euler(Rotation * touchDelta) * dir;
        currentCameraLookPos = dir + pivot;
        CameraLookPosition = currentCameraLookPos - transform.position;

        // if (Input.GetKey(KeyCode.E))
        // {
        //     Vector3 dir = newCameraPosition - pivot;
        //     dir = Quaternion.Euler(Rotation) * dir;
        //     newCameraPosition = dir + pivot;
        //     CameraPosition = newCameraPosition - transform.position;


        //      dir = currentCameraLookPos - pivot;
        //      dir = Quaternion.Euler(Rotation) * dir;
        //     currentCameraLookPos = dir + pivot;
        //     CameraLookPosition = currentCameraLookPos - transform.position;
        // }
        // if (Input.GetKey(KeyCode.Q))
        // {
        //     Vector3 dir = newCameraPosition - pivot;
        //     dir = Quaternion.Euler(-Rotation) * dir;
        //     newCameraPosition = dir + pivot;
        //     CameraPosition = newCameraPosition - transform.position;


        //     dir = currentCameraLookPos - pivot;
        //     dir = Quaternion.Euler(-Rotation) * dir;
        //     currentCameraLookPos = dir + pivot;
        //     CameraLookPosition = currentCameraLookPos - transform.position;
        // }

        mainCamera.transform.position = Vector3.Lerp(currentCameraPos, newCameraPosition, _CameraFollowSpeed * Time.deltaTime);
        mainCamera.transform.LookAt(currentCameraLookPos);

        //Debug.Log(FingerMoveDirection());
        //mainCamera.transform.position = Vector3.Lerp(currentCameraPos, newCameraPos, _CameraFollowSpeed * Time.deltaTime);
        // mainCamera.transform.LookAt(WorldCameraLookPosition);
    }

    public Camera GetCamera()
    {
        return mainCamera;
    }

    public Vector2 FingerMoveDirection()
    {
        Vector2 touchPos = Vector3.zero;
        Vector2 movedTouchPos = Vector2.zero;
        if(Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = touch.deltaPosition;

        }
        return touchPos;
    }
}
