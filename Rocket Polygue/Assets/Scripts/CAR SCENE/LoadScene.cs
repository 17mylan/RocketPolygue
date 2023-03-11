using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI loadingProgress;
    public void Start()
    {
        StartCoroutine(LoadAsynchronously(0));
    }
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Stadium");
        while(!operation.isDone)
        {
            slider.value = operation.progress;
            loadingProgress.text = Mathf.FloorToInt(operation.progress * 100f) + " %";
            yield return null;
        }
    }
}
