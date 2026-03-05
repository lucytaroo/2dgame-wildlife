using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetectionZone : MonoBehaviour
{
    private NPCController npcController; 

    private void Awake()
    {
        
        npcController = GetComponentInParent<NPCController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("in trainers view");
            npcController.StartInteraction();
        }
    }
}
