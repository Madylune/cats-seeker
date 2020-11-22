using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        catCountGoal = LevelManager.MyInstance.levels[currentLevelIndex].goal;
        maxTime = LevelManager.MyInstance.levels[currentLevelIndex].timeInSeconds;

        UIManager.MyInstance.UpdateCatCountText(catCount);
    }

    public void UpdateCatCount()
    {
        catCount++;
        UIManager.MyInstance.UpdateCatCountText(catCount);
    }
}
