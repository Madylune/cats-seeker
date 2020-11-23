using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public int currentLevelIndex = 0;
    public int catCount = 0;
    public int catCountGoal;
    public float maxTime;
    public bool timeIsOver;

    private void Awake()
    {
        catCountGoal = LevelManager.MyInstance.levels[currentLevelIndex].goal;
        maxTime = LevelManager.MyInstance.levels[currentLevelIndex].timeInSeconds;

        UIManager.MyInstance.UpdateCatCountText(catCount);
    }

    private void Update()
    {
        if (timeIsOver && catCount < catCountGoal)
        {
            StartCoroutine(UIManager.MyInstance.ShowGameOver());
        }

        if (catCount >= catCountGoal)
        {
            StartCoroutine(UIManager.MyInstance.ShowVictory());
        }
    }

    public void UpdateCatCount()
    {
        catCount++;
        UIManager.MyInstance.UpdateCatCountText(catCount);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextLevel()
    {
        currentLevelIndex++;
        catCountGoal = LevelManager.MyInstance.levels[currentLevelIndex].goal;
        maxTime = LevelManager.MyInstance.levels[currentLevelIndex].timeInSeconds;
    }
}
