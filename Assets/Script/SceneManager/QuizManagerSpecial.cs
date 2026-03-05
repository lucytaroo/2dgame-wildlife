using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManagerSpecial : MonoBehaviour
{
    [SerializeField] GameObject npc;
    [SerializeField] GameObject quizCanvas;
    [SerializeField] GameObject rightInterface;
    [SerializeField] GameObject wrongInterface;

    [SerializeField] GameObject panel;
    [SerializeField] GameObject fence1;
    



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
            fence1.SetActive(false);
            
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

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(8);
    }
}
