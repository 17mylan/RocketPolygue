using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips; // Tableau contenant les sons à jouer
    private int currentClipIndex = 0; // Index du son en cours de lecture

    private AudioSource audioSource; // Composant AudioSource pour jouer les sons

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Récupération du composant AudioSource sur l'objet courant
        audioSource.clip = audioClips[currentClipIndex]; // Chargement du premier son
        audioSource.Play(); // Lecture du premier son
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) // Si on appuie sur la touche E
        {
            PlayNextClip(); // On passe au son suivant
        }

        if (!audioSource.isPlaying) // Si le son en cours de lecture est terminé
        {
            PlayNextClip(); // On passe au son suivant
        }
    }

    private void PlayNextClip()
    {
        currentClipIndex++; // Passage au son suivant
        if (currentClipIndex >= audioClips.Length) // Si le dernier son a été joué
        {
            currentClipIndex = 0; // On revient au premier son
        }
        audioSource.clip = audioClips[currentClipIndex]; // Chargement du nouveau son
        audioSource.Play(); // Lecture du nouveau son
    }
}
