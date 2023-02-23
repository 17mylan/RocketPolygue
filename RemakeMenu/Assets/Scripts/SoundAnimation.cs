using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundAnimation : MonoBehaviour
{
    public GameObject panel;
    public GameObject logo;
    public GameObject text;

    public float animationSpeed;
    public float waitTimer;

    public bool AnimationGo;
    public bool AnimationBack;

    public void Start()
    {
        AnimationGo = true;
        StartCoroutine("AnimationTimer");
    }
    public void Update()
    {
        if(AnimationGo == true)
        {
            logo.transform.position += Vector3.left * animationSpeed * Time.deltaTime;
            panel.transform.position += Vector3.left * animationSpeed * Time.deltaTime;
            text.transform.position += Vector3.left * animationSpeed * Time.deltaTime;
        }
        if(AnimationBack == true)
        {
            logo.transform.position += Vector3.right * animationSpeed * Time.deltaTime;
            panel.transform.position += Vector3.right * animationSpeed * Time.deltaTime;
            text.transform.position += Vector3.right * animationSpeed * Time.deltaTime;
        }
    }
    public IEnumerator AnimationTimer()
    {
        yield return new WaitForSeconds(waitTimer);
        AnimationGo = false;
        AnimationBack = true;
        StartCoroutine("Wait");
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine("AnimationTimer2");
    }
    public IEnumerator AnimationTimer2()
    {
        yield return new WaitForSeconds(waitTimer);
        AnimationBack = false;
    }
}
