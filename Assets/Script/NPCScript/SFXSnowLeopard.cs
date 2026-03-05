using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSnowLeopard : MonoBehaviour
{
    public AudioClip[] SLGrowlSounds;
    private AudioSource audioSource;
    private int currentSoundIndex = 0;

    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySLGrowl()
    {
        if (SLGrowlSounds.Length == 0)
        {
            Debug.Log("No tiger growl sounds assigned.");
            return;
        }

        // Play the current sound
        audioSource.clip = SLGrowlSounds[currentSoundIndex];
        audioSource.Play();


        currentSoundIndex = (currentSoundIndex + 1) % SLGrowlSounds.Length;
    }
}
