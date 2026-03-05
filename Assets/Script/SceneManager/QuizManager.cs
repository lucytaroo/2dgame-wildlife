using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    [SerializeField] GameObject npc;
    [SerializeField] GameObject quizCanvas;
    [SerializeField] GameObject rightInterface;
    [SerializeField] GameObject wrongInterface;

    [SerializeField] GameObject panel;



    private void Start()
    {
        
        //quizCanvas.SetActive(false);
        rightInterface.SetActive(false);
        wrongInterface.SetActive(false);
        panel.SetActive(false);
    }

    public void OnAnswerSelected(bool isCorrect)
    {
        Time.timeScale = 0f;
        if (isCorrect)
        {
            // Correct answer logic
            npc.SetActive(false); // Make NPC disappear
            quizCanvas.SetActive(false); // Hide quiz UI
            rightInterface.SetActive(true); // Show "Right" interface
        }
        else
        {
            // Wrong answer logic
            quizCanvas.SetActive(false); // Hide quiz UI
            wrongInterface.SetActive(true); // Show "Wrong" interface
        }
    }


    public void ContinueButt(bool isCorrect)
    {
        if (isCorrect)
        {
            rightInterface.SetActive(false); 
            panel.SetActive(false);
        }
        else
        {
            wrongInterface.SetActive(false);
            panel.SetActive(false);
            LoadNextLevel();
        }
        Time.timeScale = 1f;
    }

    
    public void ContinueButtICE(bool isCorrect)
    {
        if (isCorrect)
        {
            rightInterface.SetActive(false);
            panel.SetActive(false);
        }
        else
        {
            wrongInterface.SetActive(false);
            panel.SetActive(false);
            LoadNextLevelICE();
        }
        Time.timeScale = 1f;
    }
    
    private void LoadNextLevel()
    {
        //SceneManager.LoadScene(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void LoadNextLevelICE()
    {
        //SceneManager.LoadScene(8);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
