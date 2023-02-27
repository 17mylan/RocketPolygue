using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHoverSimple : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip PointerEnterSound;
    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
        audioSource.PlayOneShot(PointerEnterSound);
    }
    public void PointerExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
