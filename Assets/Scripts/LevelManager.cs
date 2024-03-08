using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    public GameObject deathScreen;
    public TextMeshProUGUI scoreText;
    private AsyncOperation loadingSceneAsync;
    public int score;

    private void Awake()
    {
        manager = this;
    }

    public void GameOver()
    {
        deathScreen.SetActive(true);
        scoreText.text = "Score: " + score.ToString();

        //I paused the game using Time.timeScale and set it zero and turned the player gameobject off instead here.
        Time.timeScale = 0;
        playerscript.instance.gameObject.SetActive(false);

        //Lets Instead load the Scene Asynchronously to avoid freezes, longer loading times,
        //allows us to to dynamic loading and unloading, and better manage our memory
        loadingSceneAsync = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        loadingSceneAsync.allowSceneActivation = false;
    }

    public void ReplayGame()
    {
        //Set the Time.timeScale back to 1
        Time.timeScale = 1;
        loadingSceneAsync.allowSceneActivation = true;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
