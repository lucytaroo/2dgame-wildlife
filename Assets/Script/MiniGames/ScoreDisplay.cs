using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        var topScores = ScoreManager.instance.GetTopScores();


        scoreText.text = "Top 3 Scores:\n";
        for (int i = 0; i < topScores.Count; i++)
        {
            scoreText.text += $"{i + 1}. {topScores[i]}\n"; // Display rank and score
        }
    }
}
