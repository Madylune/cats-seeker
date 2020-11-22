using System.Collections;
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
    [SerializeField] private GameObject gameOverPanel;

    public void UpdateCatCountText(int newValue)
    {
        catCountText.text = newValue.ToString() + "/" + GameManager.MyInstance.catCountGoal.ToString();
    }

    public IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
