using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera mainCamera;
    public Transform crosshair;
    public AudioSource audioSource;
    public AudioClip shootSound;
    private bool isGameActive=true;


    void Update()
    {
        if (isGameActive && Input.GetMouseButtonDown(0)) 
        {
            Shoot();
            PlayShootSound();
        }
    }

    public void SetGameActive(bool state)
    {
        isGameActive = state; // Allow external scripts to control shooting
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                target.OnHit();
            }
        }
    }

    void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // Play the sound clip
        }
        else
        {
            Debug.LogWarning("AudioSource or ShootSound not assigned in the Inspector!");
        }
    }
}
