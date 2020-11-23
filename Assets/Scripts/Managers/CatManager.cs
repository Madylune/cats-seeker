using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
    [SerializeField] private GameObject catPrefab;

    private int catCount;

    private void Start()
    {
        StartCoroutine(SpawnCats());
    }

    public IEnumerator SpawnCats()
    {
        catCount = 0;
        while (catCount < GameManager.MyInstance.catCountGoal)
        {
            Vector3 catPos = LevelManager.MyInstance.levels[GameManager.MyInstance.currentLevelIndex].catPositions[catCount].position;
            GameObject cat = Instantiate(catPrefab, catPos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            catCount++;

            if (cat)
            {
                cat.transform.parent = transform; // Children of this
            }
        }
    }

    public void ResetCats()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject cat = transform.GetChild(i).gameObject;
            Destroy(cat); 
        }
    }
}
