﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField] private Text catCountText;
    [SerializeField] private Text countdownText;

    public void UpdateCatCountText(int newValue)
    {
        catCountText.text = newValue.ToString() + "/" + GameManager.MyInstance.catCountGoal.ToString();
    }

    public void UpdateCountdownText(float newValue)
    {
        countdownText.text = newValue.ToString();
    }
}