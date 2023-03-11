using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float letterDelay = 0.5f;
    public string wordToWrite = "MYLAN";

    private TMPro.TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(WriteWord());
        StartCoroutine(LoadAsynchronously(1));
    }

    IEnumerator WriteWord()
    {
        string currentWord = "";
        for (int i = 0; i < wordToWrite.Length; i++)
        {
            currentWord += wordToWrite[i];
            textMesh.text = currentWord;
            yield return new WaitForSeconds(letterDelay);
        }
    }
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        yield return new WaitForSeconds(0.1F);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Stadium");
        while(!operation.isDone)
        {
            yield return null;
        }
    }
}
