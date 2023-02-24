using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OnHover : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip PointerEnterSound;
    public float buttonSize;
    public TextMeshProUGUI textColor;
    public Color color;
    public Color nativeColor;
    public Button myButton;
    public GameObject ping;
    public void PointerEnter()
    {
        transform.localScale = new Vector2(buttonSize, buttonSize);
        //textColor.color = color;
        Image buttonImage = myButton.GetComponent<Image>();
        buttonImage.color = color;
        audioSource.PlayOneShot(PointerEnterSound);
        InstantiateImage();
    }
    public void PointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
        //textColor.color = nativeColor;
        Image buttonImage = myButton.GetComponent<Image>();
        buttonImage.color = nativeColor;
        DestroyImage();
    }
    public void InstantiateImage()
    {
        GameObject newImage = Instantiate(ping);
        newImage.tag = "LittleFeedBackImage";
        newImage.transform.SetParent(transform, false);
        newImage.transform.position = newImage.transform.position + new Vector3(0, 0, 0.80f);
    }
    public void DestroyImage()
    {
        DestroyImmediate(GameObject.Find("Image(Clone)"), true);
    }
}
