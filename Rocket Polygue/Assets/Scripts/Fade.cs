using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "PlayGround")
        {
            animator.Play("FadeToWhite");
            StartCoroutine(WaitTime());
        }
    }
    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
