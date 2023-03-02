using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("Stadium");
    }
}
