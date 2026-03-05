using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCAnimalLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueCanvas;

    public GameObject postcanvas;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    private bool dialogueActived;
    private int step;

    private void Start()
    {
        

    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && dialogueActived == true)
        {

            if (step >= dialogueWords.Length)
            {
                dialogueCanvas.SetActive(false);
                Time.timeScale = 0;
                Invoke("CanvasTransition",0f);

                step = 0;
            }
            else
            {
                dialogueCanvas.SetActive(true);            
                dialogueText.text = dialogueWords[step];
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player exited NPC range");
        dialogueActived = false;
        dialogueCanvas.SetActive(false);
    }

    void CanvasTransition()
    {
        postcanvas.SetActive(true);
        Debug.Log("Open Canvas");
    }

    public void SceneTransitionJungle()
    {
        SceneManager.LoadScene(7);
        Time.timeScale = 1f;
    }

    public void SceneTransitionSnow()
    {
        SceneManager.LoadScene(11);
        Time.timeScale = 1f;
    }

    public void SceneTransitionFlow2Snow()
    {
        SceneManager.LoadScene(16);
        Time.timeScale = 1f;
    }
    public void SceneTransitionFlow2Tiger()
    {
        SceneManager.LoadScene(17);
        Time.timeScale = 1f;
    }
}
