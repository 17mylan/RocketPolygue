using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TA_Image : MonoBehaviour
{
	public float fadeTime = 1f; // The time it takes to fade in the GameObject
    private float currentAlpha = 0f; // The current alpha value of the GameObject

    private Image imageI; // Reference to the SpriteRenderer component of the GameObject
    public bool isAnim = true;

    private void Start()
    {
        imageI = GetComponent<Image>();
        isAnim = true;
        currentAlpha = 0f;
    }

    private void Update()
    {
        if(isAnim)
        {
            // Increase the current alpha value over time using Mathf.Lerp
            currentAlpha = Mathf.Lerp(currentAlpha, 1f, fadeTime * Time.deltaTime);

            // Create a new Color with the same RGB values as the original color, but with the updated alpha value
            Color newColor = new Color(imageI.color.r, imageI.color.g, imageI.color.b, currentAlpha);

            // Assign the new color to the SpriteRenderer component
            imageI.color = newColor;
            if (currentAlpha >= 0.99f)
                isAnim = false;
        }
    }
}
