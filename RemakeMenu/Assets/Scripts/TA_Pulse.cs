using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TA_Pulse : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private Animator animator;
    public float minAlpha = 0.15f;
    public float maxAlpha = 1.0f;
    public float pulseSpeed = 1.5f;

    private bool increasingAlpha = false;
    public void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Wait1Sec());
    }
    IEnumerator Wait1Sec()
    {
        yield return new WaitForSeconds(1F);
        animator.enabled = false;
        increasingAlpha = true;
    }
    private void Update()
    {
        float alpha = textMeshPro.color.a;

        if (increasingAlpha)
        {
            alpha += Time.deltaTime * pulseSpeed;
            if (alpha >= maxAlpha)
            {
                alpha = maxAlpha;
                increasingAlpha = false;
            }
        }
        else
        {
            alpha -= Time.deltaTime * pulseSpeed;
            if (alpha <= minAlpha)
            {
                alpha = minAlpha;
                increasingAlpha = true;
            }
        }

        Color color = textMeshPro.color;
        color.a = alpha;
        textMeshPro.color = color;
    }
}
