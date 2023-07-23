using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] List<AudioClip> backgroundSongs;
    AudioSource audioSource;
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource footstepAudioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMusic();
        FootstepAudio();
    }

    void ChangeMusic()
    {
        if(!audioSource.isPlaying)
        {
            switch(gameManager.GetRemainingCheckpoints())
            {
                case int n when (n <= 15 && n > 12):
                //audioSource.PlayOneShot(backgroundSongs[0]);
                audioSource.clip = backgroundSongs[0];
                audioSource.volume = 0.25f;
                audioSource.Play();
                break;

                case int n when (n <= 12 && n > 7):
                audioSource.clip = backgroundSongs[1];
                audioSource.volume = 0.35f;
                audioSource.Play();
                break;
                
                case int n when (n <=7 && n > 0):
                audioSource.clip = backgroundSongs[2];
                audioSource.volume = 0.45f;
                audioSource.Play();
                break;

                default:
                audioSource.clip = backgroundSongs[3];
                audioSource.volume = 0.55f;
                audioSource.Play();
                break;
            }
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
