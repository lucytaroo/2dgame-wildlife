using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCVillain : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueCanvas;

    public string battleSceneName;

    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    [SerializeField]
    private string[] speaker;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;

    public GameObject canvasDialogue; //popup
    public GameObject picture; //popup

    private bool dialogueActived;
    private int step;

    private void Start()
    {
        dialogueCanvas.SetActive(false);

        if (picture != null)
        {
            picture.SetActive(false); 
        }
        if (canvasDialogue != null)
        {
            canvasDialogue.SetActive(false); // Ensure the canvas is initially inactive
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && dialogueActived == true)
        {

            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                dialogueActived = false;
                Time.timeScale = 1f;
                Invoke("TransitionToBattle", 1f);

                step = 0;
            }
            else
            {
                dialogueCanvas.SetActive(true);
                speakerText.text = speaker[step];
                dialogueText.text = dialogueWords[step];
                portraitImage.sprite = portrait[step];

                step++;
                Time.timeScale = 0;

            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entered NPC range");
            dialogueActived = true;
        }
        if (picture != null)
        {
            picture.SetActive(true); // Show the picture
        }
        if (canvasDialogue != null)
        {
            canvasDialogue.SetActive(true); // Show the dialogue canvas
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player exited NPC range");
        dialogueActived = false;
        dialogueCanvas.SetActive(false);
        if (picture != null)
        {
            picture.SetActive(false); // Hide the picture
        }
        if (canvasDialogue != null)
        {
            canvasDialogue.SetActive(false); // Hide the dialogue canvas
        }
    }

    void TransitionToBattle()
    {
        SceneManager.LoadScene(battleSceneName);
        Debug.Log("Changing Scene");
    }
}
