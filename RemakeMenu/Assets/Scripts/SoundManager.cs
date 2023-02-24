using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public GameObject canvasSongName;
    public Text playedSong;
    public AudioClip[] audioClips;
    private int currentClipIndex = 0;
    public float waitTimerForHideSongName;
    private AudioSource audioSource;

    public bool soundCooldown = false;
    public float waitTimerCooldownSong;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
    }
    public void SoundAnimation()
    {
        canvasSongName.SetActive(true);
        playedSong.text = "Music | Now playing: '" + audioClips[currentClipIndex].name + "' by Throttle.\nPress 'N' to play next sound.".ToString();
        StartCoroutine("HideSongName");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if(soundCooldown == false)
                PlayNextClip();
        }

        if (!audioSource.isPlaying)
        {
            if(soundCooldown == false)
                PlayNextClip();
        }
    }

    private void PlayNextClip()
    {   
        canvasSongName.SetActive(true);
        StartCoroutine("HideSongName");
        StartCoroutine("CooldownSong");
        currentClipIndex++;
        if (currentClipIndex >= audioClips.Length)
        {
            currentClipIndex = 0;
        }
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play(); 
        print("Music | Now playing: '" + audioClips[currentClipIndex].name + "' by Throttle.");
        playedSong.text = "Music | Now playing: '" + audioClips[currentClipIndex].name + "' by Throttle.\nPress 'N' to play next sound.".ToString();
    }
    public IEnumerator CooldownSong()
    {
        soundCooldown = true;
        yield return new WaitForSeconds(waitTimerCooldownSong);
        soundCooldown = false;
    }
    public IEnumerator HideSongName()
    {
        yield return new WaitForSeconds(waitTimerForHideSongName);
        canvasSongName.SetActive(false);
    }
}
