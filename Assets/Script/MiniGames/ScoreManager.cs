using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton for global access
    public int score = 0; // Tracks the player's score
    [SerializeField] TextMeshProUGUI scoreCount;
    private List<int> topScores = new List<int>(3);

    void Start()
    {
        ResetScore();
        //ScoreManager.instance.ResetScore();
    }
    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            LoadScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreCount.text = "Score: " + score;

    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SaveScore()
    {
        topScores.Add(score); // Add current score to the list
        topScores.Sort((a, b) => b.CompareTo(a)); // Sort in descending order
        if (topScores.Count > 3) // Ensure only 3 scores are kept
        {
            topScores.RemoveAt(topScores.Count - 1);
        }
        SaveScores(); // Save to PlayerPrefs
    }

    private void LoadScores()
    {
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey("TopScore" + i))
            {
                topScores.Add(PlayerPrefs.GetInt("TopScore" + i));
            }
            else
            {
                topScores.Add(0); // Default value if no score exists
            }
        }
    }

    private void SaveScores()
    {
        for (int i = 0; i < topScores.Count; i++)
        {
            PlayerPrefs.SetInt("TopScore" + i, topScores[i]);
        }
    }

    public List<int> GetTopScores()
    {
        return topScores;
    }
}
