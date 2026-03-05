using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalInfo : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvasDialogue;
    public GameObject picture; 
    private bool isPlayerInRange = false;

    void Start()
    {
        if (canvas != null)
        {
            canvas.SetActive(false); // Ensure the canvas is initially inactive
        }

        if (canvasDialogue != null)
        {
            canvasDialogue.SetActive(false); // Ensure the canvas is initially inactive
        }

        if (picture != null)
        {
            picture.SetActive(false); // Ensure the picture is initially inactive
        }
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            

            if (canvas != null && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Activate Canvas");
                canvas.SetActive(!canvas.activeSelf); // Toggle canvas visibility
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Enter Range");
            if (picture != null)
            {
                picture.SetActive(true); // Show the picture
            }
            if (canvasDialogue != null)
            {
                canvasDialogue.SetActive(true); // Show the dialogue canvas
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("ExitRange");
            if (picture != null)
            {
                picture.SetActive(false); // Hide the picture
            }
            if (canvasDialogue != null)
            {
                canvasDialogue.SetActive(false); // Hide the dialogue canvas
            }
        }
    }
}
