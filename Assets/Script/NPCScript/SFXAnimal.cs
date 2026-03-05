using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAnimal : MonoBehaviour
{
    public AudioClip[] tigerGrowlSounds; 
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

    public void PlayTigerGrowl()
    {
        if (tigerGrowlSounds.Length == 0)
        {
            Debug.Log("No tiger growl sounds assigned.");
            return;
        }

        // Play the current sound
        audioSource.clip = tigerGrowlSounds[currentSoundIndex];
        audioSource.Play();

        
        currentSoundIndex = (currentSoundIndex + 1) % tigerGrowlSounds.Length;
    }
}
