using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter Exit Point");
            LoadNextLevel();
        }   
    }

    public void RestartShootingGames()
    {
        foreach (var obj in FindObjectsOfType<MonoBehaviour>())
        {
            if (obj.gameObject.CompareTag("Persistent"))
            {
                Destroy(obj.gameObject);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void maintominigame()
    {
        SceneManager.LoadScene(1);
    }

    public void minitoquiz()
    {
        //SceneManager.LoadScene(8);
    }

    public void minitoshooting()
    {
        SceneManager.LoadScene(2);
    }

    public void minitoscore()
    {
        SceneManager.LoadScene(3);
    }

    public void shootingtomain()
    {
        SceneManager.LoadScene(0);
    }

    public void maintolevel()
    {
        SceneManager.LoadScene(4);
    }

    public void housetoenv1()
    {
        SceneManager.LoadScene(6);
    }

    public void env1toenv2()
    {
        SceneManager.LoadScene(7);
    }

    public void env1tobattle1()
    {
        SceneManager.LoadScene(8);
    }

    public void env2tobattle2()
    {
        //SceneManager.LoadScene(6);
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

}
