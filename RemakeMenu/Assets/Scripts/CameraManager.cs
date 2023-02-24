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
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject mainCanvas;

    public bool canClick = false;
    public bool canPlaySong = true;
    public bool firstInteraction = true;
    public SoundManager soundManager;

    //[Header("Boolean")]
    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
            if(firstInteraction)
            {
                if(canClick)
                {
                    if(canPlaySong)
                    {
                        audioSource.PlayOneShot(audioClip);
                        canPlaySong = false;
                    }
                    soundManager.SoundAnimation();
                    canvasCameraPressAnyKey.SetActive(false);
                    currentCamera.Priority--;
                    StartCoroutine("CameraTransition");
                }
            }
        }
    }
    public IEnumerator CameraTransition()
    {
        yield return new WaitForSeconds(waitTimer);
        firstInteraction = false;
        cameraCarView.SetActive(true);
        cameraPressAnyKey.SetActive(false);
        vCam1.SetActive(false);
        vCam2.SetActive(false);
        mainCanvas.SetActive(true);
    }
}