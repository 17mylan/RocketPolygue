using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject cameraPressAnyKey;
    public GameObject canvasCameraPressAnyKey;
    public GameObject vCam1;
    public GameObject vCam2;
    public GameObject cameraCarView;
    public CinemachineVirtualCamera currentCamera;
    [Header("Floats Numbers")]
    public float waitTimer;

    public bool canClick = false;

    //[Header("Boolean")]
    void Start()
    {
        cameraCarView.SetActive(false);
        StartCoroutine(WaitBeforeAnyClick());
    }
    IEnumerator WaitBeforeAnyClick()
    {
        yield return new WaitForSeconds(1.2F);
        canClick = true;
    }
    void Update()
    {
        if(Input.anyKey)
        {
            if(canClick)
            {
                canvasCameraPressAnyKey.SetActive(false);
                currentCamera.Priority--;
                StartCoroutine("CameraTransition");
            }
        }
    }
    public IEnumerator CameraTransition()
    {
        yield return new WaitForSeconds(waitTimer);
        cameraCarView.SetActive(true);
        cameraPressAnyKey.SetActive(false);
        vCam1.SetActive(false);
        vCam2.SetActive(false);
    }
}