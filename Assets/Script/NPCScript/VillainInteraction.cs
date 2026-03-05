using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillainInteraction : MonoBehaviour
{
    public string battleSceneName; // Name of the scene for the battle
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartConversation();
        }
    }

    void StartConversation()
    {
        // Display conversation logic here (e.g., UI pop-up or dialogue system)
        Debug.Log("Starting conversation with the villain...");

        // After the conversation ends, transition to the battle scene
        Invoke("TransitionToBattle", 2f); // Adjust delay as needed for conversation
    }

    void TransitionToBattle()
    {
        SceneManager.LoadScene(battleSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
