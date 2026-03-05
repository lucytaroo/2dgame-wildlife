using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    public float timeLimit = 15f; 
    private float timer;
    private bool isGameActive = false;
    [SerializeField] TextMeshProUGUI timertext;
    public GameObject TimeUp; //canvas
    [SerializeField] TextMeshProUGUI finalScoreText;
    
    [SerializeField] TextMeshProUGUI countdownText;

    public TargetSpawner targetSpawner;
    

    void Start()
    {
        Shooting shooting = FindObjectOfType<Shooting>();
        Time.timeScale = 1f; // Reset time scale in case it was set to 0
        timertext.color = Color.white; // Reset the color
        timer = timeLimit;
        shooting.SetGameActive(false);


        //targetSpawner.SpawnTarget();
        isGameActive = false; // Ensure this is reset


        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }
        StartCoroutine(CountdownBeforeStart());


    }

    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timer <= 0f)
            {
                timer = 0f; 
                timertext.color = Color.red;
                EndGame();
                Time.timeScale = 0f;
                

            }
        }
    }

    private void EndGame()
    {
        isGameActive = false;
        Shooting shooting = FindObjectOfType<Shooting>(); // Find the Shooting script in the scene
        if (shooting != null)
        {
            shooting.SetGameActive(false); // Disable shooting
        }
        TimeUp.SetActive(true);
        Debug.Log("Time's up! Game over.");

        int finalScore = ScoreManager.instance.GetScore();
        finalScoreText.text = "Score: " + finalScore;
        ScoreManager.instance.SaveScore();
   
    }

    private IEnumerator CountdownBeforeStart()
    {
        countdownText.gameObject.SetActive(true); // Show the countdown text
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false); // Hide the countdown text

        StartGame();
    }

    private void StartGame()
    {
        Shooting shooting = FindObjectOfType<Shooting>();
        isGameActive = true;
        targetSpawner.SpawnTarget();
        shooting.SetGameActive(true);
    }

}
