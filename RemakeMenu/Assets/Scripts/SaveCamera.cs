using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveCamera : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Vector3 cameraRotation;

    void Start()
    {
        cameraPosition = transform.position;
        cameraRotation = transform.rotation.eulerAngles;
        PlayerPrefs.SetFloat("cameraPosX", cameraPosition.x);
        PlayerPrefs.SetFloat("cameraPosY", cameraPosition.y);
        PlayerPrefs.SetFloat("cameraPosZ", cameraPosition.z);
        PlayerPrefs.SetFloat("cameraRotX", cameraRotation.x);
        PlayerPrefs.SetFloat("cameraRotY", cameraRotation.y);
        PlayerPrefs.SetFloat("cameraRotZ", cameraRotation.z);
    }
    void ResetCamera()
    {
        cameraPosition.x = PlayerPrefs.GetFloat("cameraPosX");
        cameraPosition.y = PlayerPrefs.GetFloat("cameraPosY");
        cameraPosition.z = PlayerPrefs.GetFloat("cameraPosZ");
        cameraRotation.x = PlayerPrefs.GetFloat("cameraRotX");
        cameraRotation.y = PlayerPrefs.GetFloat("cameraRotY");
        cameraRotation.z = PlayerPrefs.GetFloat("cameraRotZ");
        transform.position = cameraPosition;
        transform.rotation = Quaternion.Euler(cameraRotation);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ResetCamera();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Stadium");
        }
    }
}
