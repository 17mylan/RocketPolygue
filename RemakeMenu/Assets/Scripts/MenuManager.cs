using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip enterClickSound;
    public void PlaySound()
    {
        audioSource.PlayOneShot(enterClickSound);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
