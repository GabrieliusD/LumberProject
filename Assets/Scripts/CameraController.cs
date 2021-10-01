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
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 currentCameraPos = mainCamera.transform.position;
        Vector3 newCameraPos = transform.TransformPoint(CameraPosition);
        
        
        Vector3 pivot = transform.position;
        

        Vector3 WorldCameraLookPosition = this.transform.TransformPoint(CameraLookPosition);
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 dir = WorldCameraLookPosition - pivot;
            dir = Quaternion.Euler(Rotation) * dir;
            WorldCameraLookPosition = dir + pivot;
            CameraLookPosition = transform.InverseTransformPoint(WorldCameraLookPosition);


            dir = newCameraPos - pivot;
            dir = Quaternion.Euler(Rotation) * dir;
            newCameraPos = dir + pivot;
            CameraPosition = transform.InverseTransformPoint(newCameraPos);
        }
        mainCamera.transform.position = Vector3.Lerp(currentCameraPos, newCameraPos, _CameraFollowSpeed*Time.deltaTime);
        mainCamera.transform.LookAt(WorldCameraLookPosition);
    }

    public Camera GetCamera()
    {
        return mainCamera;
    }
}
