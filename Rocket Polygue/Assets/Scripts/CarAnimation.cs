using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    public GameObject imageCar;
    public Animator animator;
    public bool isClicked = false;
    public bool cooldown;
    public MenuManager menuManager;
    private void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }
    public void ButtonClick()
    {
        if(!isClicked && !cooldown)
        {
            if(!imageCar.activeSelf)
                menuManager.CloseAllPanels();
                menuManager.PlaySound(1);
                imageCar.SetActive(true);
                isClicked = true;
        }
        else if(isClicked && !cooldown)
        {
            if(imageCar.activeSelf)
                animator.Play("AnnonceBacking");
                isClicked = false;
                cooldown = true;
                menuManager.PlaySound(2);
                StartCoroutine("wait");
        }
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        imageCar.SetActive(false);
        cooldown = false;
    }
}
