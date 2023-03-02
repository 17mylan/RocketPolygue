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
    public GameObject garageButton;
    public GameObject Garage;
    public GameObject Settings;
    public GameObject settingsButton;
    public GameObject counterFPS;
    public GameObject Credits;
    public GameObject creditsButton;
    private void Start()
    {
        onHover = FindObjectOfType<OnHover>();
        if(PlayerPrefs.GetString("ShowFPS") == "Active")
        {
            counterFPS.SetActive(true);
        }
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
    public void OpenSettings()
    {
        PlaySound(1);
        CloseAllPanels();
        Settings.SetActive(true);
        settingsButton.transform.localScale = new Vector2(1f, 1f);
        creditsButton.transform.localScale = new Vector2(1f, 1f);
    }
    public void CloseSettings()
    {
        PlaySound(2);
        onHover.PointerExit();
        Settings.SetActive(false);
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
    public void OpenGarage()
    {
        PlaySound(1);
        CloseAllPanels();
        Garage.SetActive(true);
        garageButton.transform.localScale = new Vector2(1f, 1f);
    }
    public void CloseGarage()
    {
        PlaySound(2);
        onHover.PointerExit();
        Garage.SetActive(false);
    }
    public void ShowFPS()
    {
        counterFPS.SetActive(true);
        PlayerPrefs.SetString("ShowFPS", "Active");
    }
    public void HideFPS()
    {
        counterFPS.SetActive(false);
        PlayerPrefs.SetString("ShowFPS", "Disable");
    }
    public void OpenCredits()
    {
        PlaySound(1);
        CloseAllPanels();
        Credits.SetActive(true);
        creditsButton.transform.localScale = new Vector2(1f, 1f);
    }
    public void CloseCredits()
    {
        PlaySound(2);
        onHover.PointerExit();
        Credits.SetActive(false);
    }
    public void CloseAllPanels()
    {
        Profile.SetActive(false);
        QuitGame.SetActive(false);
        Garage.SetActive(false);
        Settings.SetActive(false);
        Credits.SetActive(false);
    }
    public void ChangeScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
