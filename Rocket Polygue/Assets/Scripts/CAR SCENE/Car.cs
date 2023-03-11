using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject targetObject;
    public float speedCam = 5f;
    public GameObject Car1, Car2, Car3, Car4;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if(Input.GetMouseButton(0))
            cameraObject.transform.RotateAround(targetObject.transform.position, Vector3.up, -Input.GetAxis("Mouse X")*speedCam);
        if(Input.GetMouseButton(1))
            SceneManager.LoadScene("PlayGround");
    }
    private float currentSpeed = 0.0f;
    public float maxSpeed = 2.0f;
    public float rotationSpeed = 50.0f;
    public float smoothCarMoving = 20f;
    private Rigidbody rb;
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, Time.deltaTime * smoothCarMoving);
        }
        else if (moveVertical < 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, -maxSpeed, Time.deltaTime * smoothCarMoving);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0.0f, Time.deltaTime * smoothCarMoving);
        }

        if (currentSpeed != 0)
        {
            Vector3 moveDirection = new Vector3(0.0f, 0.0f, currentSpeed);
            moveDirection = transform.TransformDirection(moveDirection);
            rb.AddForce(moveDirection, ForceMode.VelocityChange);
        }

        if (moveVertical != 0 || moveHorizontal != 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * moveHorizontal * rotationSpeed);
        }
    }
}
