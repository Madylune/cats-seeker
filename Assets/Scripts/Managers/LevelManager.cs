using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public static LevelManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }

    public Levels[] levels;

    [System.Serializable]
    public class Levels
    {
        public int goal;
        public float timeInSeconds;
    }
}
