using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    [SerializeField] private GameObject catPrefab;

    private int catCount;

    private void Start()
    {
        StartCoroutine(SpawnCat());
    }

    IEnumerator SpawnCat()
    {
        while (catCount < GameManager.MyInstance.catCountGoal)
        {
            Vector3 catPos = LevelManager.MyInstance.levels[GameManager.MyInstance.currentLevelIndex].catPositions[catCount].position;
            Instantiate(catPrefab, catPos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            catCount++;
        }
    }
}
