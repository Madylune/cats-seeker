using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float currentTime;

    private void Start()
    {
        currentTime = GameManager.MyInstance.maxTime;
        UIManager.MyInstance.UpdateCountdownText(Mathf.Round(currentTime));
    }

    private void Update()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            UIManager.MyInstance.UpdateCountdownText(Mathf.Round(currentTime));
        }
        else
        {
            currentTime = 0;
        }
    }
}
