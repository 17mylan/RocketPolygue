using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TA_Text : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float duration;

    private void Start()
    {
        StartCoroutine(ChangeAlpha());
    }

    IEnumerator ChangeAlpha()
    {
        yield return new WaitForSeconds(1f);
        float startTime = Time.time;
        Color startColor = textMeshPro.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            textMeshPro.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        textMeshPro.color = endColor;
    }
}
