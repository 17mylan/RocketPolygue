using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public List<GameObject> carList; // la liste des GameObjects à contrôler
    private int activeIndex = 0; // l'index du GameObject actif
    public bool canPlaySong = true;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float waitTimerSong;

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

    IEnumerator WaitSong()
    {
        yield return new WaitForSeconds(waitTimerSong);
        canPlaySong = true;
    }
    public void NextCar()
    {
        if(canPlaySong)
            {
                audioSource.PlayOneShot(audioClip);
                canPlaySong = false;
                StartCoroutine(WaitSong());
            }
            activeIndex = PlayerPrefs.GetInt("SavedCar", activeIndex);
            // désactiver le GameObject actif
            carList[activeIndex].SetActive(false);

            // passer à l'index suivant, ou revenir au début si on est à la fin de la liste
            activeIndex = (activeIndex + 1) % carList.Count;

            // activer le nouveau GameObject actif
            carList[activeIndex].transform.position = new Vector3(carList[activeIndex].transform.position.x, 0.5f, carList[activeIndex].transform.position.z);
            carList[activeIndex].SetActive(true);
            PlayerPrefs.SetInt("SavedCar", activeIndex);
            PlayerPrefs.SetString("SavedCarName", carList[activeIndex].name);
    }
}

    /*private void Update()
    {
        // vérifier si l'utilisateur a cliqué sur la souris
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(canPlaySong)
            {
                audioSource.PlayOneShot(audioClip);
                canPlaySong = false;
                StartCoroutine(WaitSong());
            }
            activeIndex = PlayerPrefs.GetInt("SavedCar", activeIndex);
            // désactiver le GameObject actif
            carList[activeIndex].SetActive(false);

            // passer à l'index suivant, ou revenir au début si on est à la fin de la liste
            activeIndex = (activeIndex + 1) % carList.Count;

            // activer le nouveau GameObject actif
            carList[activeIndex].SetActive(true);
            PlayerPrefs.SetInt("SavedCar", activeIndex);
        }
    }*/