using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] List<AudioClip> backgroundSongs;
    AudioSource audioSource;
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource footstepAudioSource;
    [SerializeField] float volumeFadeAmount = 0.05f;
    string currentSong;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMusic();
        PlayNextSong();
        FootstepAudio();
    }

    void PlayNextSong()
    {
        if(!audioSource.isPlaying)
        {
            switch(gameManager.GetRemainingCheckpoints())
            {
                case int n when (n <= 15 && n > 8):
                    audioSource.clip = backgroundSongs[1];
                    audioSource.volume = 0.35f;
                    audioSource.Play();
                    currentSong = "Menu Music";
                    break;

                /*case int n when (n <= 12 && n > 7):
                    audioSource.clip = backgroundSongs[2];
                    audioSource.volume = 0.35f;
                    audioSource.Play();
                    currentSong = "Outtake";
                    break;*/
                
                case int n when (n <=8 && n > 0):
                    audioSource.clip = backgroundSongs[2];
                    audioSource.volume = 0.35f;
                    audioSource.Play();
                    currentSong = "Outtake";
                    break;

                default:
                    audioSource.clip = backgroundSongs[3];
                    audioSource.volume = 0.35f;
                    audioSource.Play();
                    currentSong = "Two Dips in the Water_1";
                    break;
            }
        }
    }

    public void FadeMusic()
    {
        audioSource.volume -= volumeFadeAmount * Time.deltaTime;
        if(audioSource.volume <= 0f)
        {
            audioSource.Stop();
        }
    }

    void ChangeMusic()
    {
        /*if(gameManager.GetRemainingCheckpoints() == 12 && currentSong != "Outtake")
        {
            FadeMusic();
        }*/

        if(gameManager.GetRemainingCheckpoints() == 8 && currentSong != "Outtake")
        {
            FadeMusic();
        }

        if(gameManager.GetRemainingCheckpoints() == 0 && currentSong != "Two Dips in the Water_1")
        {
            FadeMusic();
        }
    }
        
    void FootstepAudio()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            footstepAudioSource.enabled = true;
        }
        else
        {
            footstepAudioSource.enabled = false;
        }
    }
}
