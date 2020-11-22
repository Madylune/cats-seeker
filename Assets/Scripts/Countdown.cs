using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Text minutesText;
    [SerializeField] private Text secondsText;
    [SerializeField] private Text seconds100Text;
    [SerializeField] private Text[] separators;

    private float currentTime;
    private float endTime = 0f;
    private bool isRunning;

    private void Start()
    {
        GameManager.MyInstance.timeIsOver = false;
        currentTime = GameManager.MyInstance.maxTime;
        minutesText.text = currentTime.ToString();
        secondsText.text = seconds100Text.text = "00";
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            if (currentTime >= endTime)
            {
                currentTime -= Time.deltaTime;
                int minutesInt = (int)currentTime / 60;
                int secondsInt = (int)currentTime % 60;
                int seconds100Int = (int)(Mathf.Floor((currentTime - (secondsInt + minutesInt * 60)) * 100));

                if (currentTime < GameManager.MyInstance.maxTime / 2)
                {
                    minutesText.color = secondsText.color = seconds100Text.color = Color.red;
                    foreach (Text separator in separators)
                    {
                        separator.color = Color.red;
                    }
                }

                minutesText.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
                secondsText.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
                seconds100Text.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
            }
            else
            {
                currentTime = endTime;
                isRunning = false;
                StopCountdown();
            }
        }
    }

    private void StopCountdown()
    {
        minutesText.text = secondsText.text = seconds100Text.text = "00";
        GameManager.MyInstance.timeIsOver = true;
    }
}
