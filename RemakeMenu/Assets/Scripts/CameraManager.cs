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
    public GameObject playerCanvas;
    public CinemachineVirtualCamera currentCamera;
    [Header("Floats Numbers")]
    public float waitTimer;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject mainCanvas;

    public bool canClick = false;
    public bool canPlaySong = true;
    public bool firstInteraction = true;
    public SoundManager soundManager;

    //[Header("Boolean")]
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        cameraCarView.SetActive(false);
        StartCoroutine("WaitBeforeAnyClick");
    }
    IEnumerator WaitBeforeAnyClick()
    {
        yield return new WaitForSeconds(1.6f);
        canClick = true;
    }
    void Update()
    {
        if(firstInteraction)
        {
            if(Input.anyKey)
            {
                if(canClick)
                {
                    if(canPlaySong)
                    {
                        audioSource.PlayOneShot(audioClip);
                        canPlaySong = false;
                        StartCoroutine("CameraTransition");
                    }
                    currentCamera.Priority = currentCamera.Priority - 200;
                }
            }
        }
    }
    public IEnumerator CameraTransition()
    {
        soundManager.SoundAnimation();
        canvasCameraPressAnyKey.SetActive(false);
        yield return new WaitForSeconds(waitTimer);
        firstInteraction = false;
        cameraCarView.SetActive(true);
        cameraPressAnyKey.SetActive(false);
        vCam1.SetActive(false);
        vCam2.SetActive(false);
        mainCanvas.SetActive(true);
        playerCanvas.SetActive(true);
    }
}