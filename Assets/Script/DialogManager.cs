using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText ;
    [SerializeField] int lettersPerSecond ;
    //[SerializeField] GameObject quizCanvas;
    

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;
    private GameObject currentQuizCanvas;
    private GameObject currentPanel;

    private void Awake()
    {
        Instance = this; 
    }

    public void SetCurrentQuizCanvas(GameObject quizCanvas, GameObject panel)
    {
        // Set the current NPC's quiz canvas
        currentQuizCanvas = quizCanvas;
        currentPanel = panel;
    }



    public IEnumerator ShowDialog(Dialog dialog)
    {

        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);


        //StartCoroutine(TypeDialog(dialog.Lines[0]));
        currentLine = 0;
        dialogText.text = ""; 
        StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F)&& !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else 
            {
                currentLine = 0;
                OnCloseDialog?.Invoke();
                Quiz();
                
            }
            
            
        }
    }

    public IEnumerator TypeDialog(string dialog)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping=false;
    }

    public void Quiz()
    {
        
        dialogBox.SetActive(false);

        if (currentQuizCanvas != null || currentPanel != null)
        {
            currentQuizCanvas.SetActive(true); // Activate the correct quiz canvas
            currentPanel.SetActive(true);
        }
        else
        {
            Debug.Log("No quiz canvas assigned for this NPC!");
            Debug.Log("No Panel!! ");
        }
    }

    
}
