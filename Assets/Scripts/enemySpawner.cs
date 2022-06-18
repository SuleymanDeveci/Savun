using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public TextMeshProUGUI numberOfEnemytxt;
    public int numberOfEnemy;
    public bool spawnerisActive;

    private void Start()
    {
        spawnerisActive = false;
    }


    public void toggleEnemySpawner()
    {
        if(spawnerisActive == true)
        {
            spawnerisActive = false;
        }
        else
        {
            spawnerisActive = true;
        }
    }

    public void Update()
    {
        if (spawnerisActive)
        {
            spawnEnemy();
        }
    }
    public void spawnEnemy()
    {
        Instantiate(enemyPrefab1, new Vector3(Random.Range(-28,28), Random.Range(-28,28), 0), Quaternion.identity);
        numberOfEnemy++;
        numberOfEnemytxt.text = numberOfEnemy.ToString();
    }
}
