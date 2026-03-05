using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizGames : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;       // The question text
        public string[] options;         // Array of answer options
        public int correctAnswerIndex;   // Index of the correct answer
    }

    public List<Question> allQuestions;   // List of all available questions
    private List<Question> selectedQuestions; // Randomly selected questions for the game
    private int currentQuestionIndex = 0; // Index of the current question
    private int score = 0;                // Player's score

    [Header("UI Elements")]
    public TextMeshProUGUI questionText;  // Text for the question
    public TextMeshProUGUI scoreText;     // Text for the score
    public Button[] answerButtons;        // Buttons for answer options
    public GameObject resultPanel;        // Result Panel
    public TextMeshProUGUI finalScoreText;// Text for the final score

    void Start()
    {
        // Select 5 random questions from the list
        selectedQuestions = new List<Question>(allQuestions);
        for (int i = selectedQuestions.Count - 1; i > 4; i--)
        {
            selectedQuestions.RemoveAt(Random.Range(0, selectedQuestions.Count));
        }

        // Display the first question
        DisplayQuestion();
        UpdateScoreText();
        resultPanel.SetActive(false);
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < selectedQuestions.Count)
        {
            Question currentQuestion = selectedQuestions[currentQuestionIndex];
            questionText.text = currentQuestion.questionText;

            // Assign options to buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.options.Length)
                {
                    answerButtons[i].gameObject.SetActive(true);
                    answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.options[i];
                    int index = i; // Capture index for delegate
                    answerButtons[i].onClick.RemoveAllListeners();
                    answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            EndQuiz();
        }
    }

    void CheckAnswer(int selectedAnswerIndex)
    {
        if (selectedQuestions[currentQuestionIndex].correctAnswerIndex == selectedAnswerIndex)
        {
            score++;
        }

        currentQuestionIndex++;
        DisplayQuestion();
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void EndQuiz()
    {
        resultPanel.SetActive(true);
        finalScoreText.text = "Your Score: " + score + "/" + selectedQuestions.Count;
    }

    public void RestartQuiz()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Replace with your Main Menu scene name
    }
}
