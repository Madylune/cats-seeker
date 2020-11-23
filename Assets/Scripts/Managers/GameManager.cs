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

    [SerializeField] private Countdown countdown;

    private CatManager catManager;

    private void Awake()
    {
        Time.timeScale = 1f;

        catCountGoal = LevelManager.MyInstance.levels[currentLevelIndex].goal;
        maxTime = LevelManager.MyInstance.levels[currentLevelIndex].timeInSeconds;

        UIManager.MyInstance.UpdateCatCountText(catCount);
        UIManager.MyInstance.UpdateLevelText(currentLevelIndex + 1);
    }

    private void Start()
    {
        catManager = GetComponent<CatManager>();
        timeIsOver = false;
    }

    private void Update()
    {
        if (timeIsOver && catCount < catCountGoal)
        {
            StartCoroutine(UIManager.MyInstance.ShowGameOver());
            timeIsOver = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.MyInstance.TogglePauseMenu();
        }
    }

    public void UpdateCatCount()
    {
        catCount++;
        UIManager.MyInstance.UpdateCatCountText(catCount);

        if (catCount >= catCountGoal)
        {
            if (currentLevelIndex + 1 < LevelManager.MyInstance.levels.Length)
            {
                StartCoroutine(UIManager.MyInstance.ShowVictory());
                timeIsOver = false;
            }
            else
            {
                StartCoroutine(UIManager.MyInstance.ShowEndPanel());
                timeIsOver = false;
            }
        }
    }

    public void RestartGame()
    {
        catCount = 0;

        Time.timeScale = 1f;
        UIManager.MyInstance.CloseGameOver();
        UIManager.MyInstance.UpdateCatCountText(catCount);

        countdown.StartCountdown();

        catManager.ResetCats();
        StartCoroutine(catManager.SpawnCats());
    }

    public void NextLevel()
    {
        currentLevelIndex++;
        catCount = 0;
        catCountGoal = LevelManager.MyInstance.levels[currentLevelIndex].goal;
        maxTime = LevelManager.MyInstance.levels[currentLevelIndex].timeInSeconds;

        Time.timeScale = 1f;
        UIManager.MyInstance.CloseVictory();
        UIManager.MyInstance.UpdateCatCountText(catCount);
        UIManager.MyInstance.UpdateLevelText(currentLevelIndex + 1);

        countdown.StartCountdown();
        StartCoroutine(catManager.SpawnCats());
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
