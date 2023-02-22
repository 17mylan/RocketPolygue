using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject targetObject;
    public float speed = 5f;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            cameraObject.transform.RotateAround(targetObject.transform.position, Vector3.up, -Input.GetAxis("Mouse X")*speed);
        }
    }
}
