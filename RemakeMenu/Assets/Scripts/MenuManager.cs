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
    public AudioClip backClickSound;

    public GameObject Profile;
    public GameObject profileButton;
    public GameObject quitButton;
    public Color nativeColor;
    public OnHover onHover;
    public GameObject QuitGame;
    private void Start()
    {
        onHover = FindObjectOfType<OnHover>();
    }
    public void PlaySound(int index)
    {
        if(index == 1)
            audioSource.PlayOneShot(enterClickSound);
        else if(index == 2)
            audioSource.PlayOneShot(backClickSound);
    }


    public void OpenProfile()
    {
        PlaySound(1);
        CloseAllPanels();
        Profile.SetActive(true);
        profileButton.transform.localScale = new Vector2(1f, 1f);
    }
    public void CloseProfile()
    {
        PlaySound(2);
        onHover.PointerExit();
        Profile.SetActive(false);
    }


    public void OpenQuitGame()
    {
        PlaySound(1);
        CloseAllPanels();
        QuitGame.SetActive(true);
        quitButton.transform.localScale = new Vector2(1f, 1f);
    }
    public void CloseQuitGame()
    {
        PlaySound(2);
        onHover.PointerExit();
        QuitGame.SetActive(false);
    }

    public void CloseAllPanels()
    {
        Profile.SetActive(false);
        QuitGame.SetActive(false);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
