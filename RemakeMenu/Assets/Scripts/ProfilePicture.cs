using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePicture : MonoBehaviour
{
    public List<Sprite> images; // Liste des images à afficher
    public Image displayImage; // Image à afficher
    public Image displayImageProfile;
    public MenuManager menuManager;

    private int currentIndex = 0; // Index courant de l'image affichée

    private void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        currentIndex = PlayerPrefs.GetInt("playerPicture");
        displayImage.sprite = images[currentIndex]; // Afficher la première image de la liste au démarrage
        displayImageProfile.sprite = images[currentIndex];
    }

    public void ChangePicture()
    {
        menuManager.PlaySound(1);
        currentIndex = (currentIndex + 1) % images.Count;
        displayImage.sprite = images[currentIndex];
        displayImageProfile.sprite = images[currentIndex];
        PlayerPrefs.SetInt("playerPicture", currentIndex);
    }
}
