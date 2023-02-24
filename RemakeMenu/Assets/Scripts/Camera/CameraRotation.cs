using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject targetObject;
    public float speed = 5f;
    public float waitTimer;
    public bool canMove = false;

    void Start()
    {
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTimer);
        canMove = true;
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(canMove)
                cameraObject.transform.RotateAround(targetObject.transform.position, Vector3.up, -Input.GetAxis("Mouse X")*speed);
        }
    }
}
