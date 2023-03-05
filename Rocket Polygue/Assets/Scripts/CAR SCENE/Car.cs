using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 200.0f;

    public Camera cameraObject;
    public GameObject targetObject;
    public float speedCam = 5f;
    public GameObject Car1, Car2, Car3, Car4;
    public void Start()
    {
        Car1.SetActive(false);
        Car2.SetActive(false);
        Car3.SetActive(false);
        Car4.SetActive(false);
        if(PlayerPrefs.GetInt("SavedCar") == 0)
        {
            Car1.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("SavedCar") == 1)
        {
            Car2.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("SavedCar") == 2)
        {
            Car3.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("SavedCar") == 3)
        {
            Car4.SetActive(true);
        }
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput);
        }
        if(Input.GetMouseButton(0))
            cameraObject.transform.RotateAround(targetObject.transform.position, Vector3.up, -Input.GetAxis("Mouse X")*speedCam);

        if(Input.GetMouseButton(1))
            SceneManager.LoadScene("PlayGround");
        
    }
}
