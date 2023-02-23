using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public List<GameObject> carList; // la liste des GameObjects à contrôler
    private int activeIndex = 0; // l'index du GameObject actif

    private void Start()
    {
        // désactiver tous les GameObjects sauf le premier
        /*for (int i = 1; i < carList.Count; i++)
        {
            carList[i].SetActive(false);
        }*/
        foreach(GameObject obj in carList)
        {
            obj.SetActive(false);
        }
        carList[PlayerPrefs.GetInt("SavedCar", activeIndex)].SetActive(true);
    }

    private void Update()
    {
        // vérifier si l'utilisateur a cliqué sur la souris
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeIndex = PlayerPrefs.GetInt("SavedCar", activeIndex);
            // désactiver le GameObject actif
            carList[activeIndex].SetActive(false);

            // passer à l'index suivant, ou revenir au début si on est à la fin de la liste
            activeIndex = (activeIndex + 1) % carList.Count;

            // activer le nouveau GameObject actif
            carList[activeIndex].SetActive(true);
            PlayerPrefs.SetInt("SavedCar", activeIndex);
        }
    }
}
