using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraPressAnyKey;
    public GameObject canvasCameraPressAnyKey;
    public GameObject cameraCarView;
    void Start()
    {
        cameraCarView.SetActive(false);
    }
    void Update()
    {
        if(Input.anyKey)
        {
            cameraPressAnyKey.SetActive(false);
            canvasCameraPressAnyKey.SetActive(false);
            cameraCarView.SetActive(true);
        }
    }
}
