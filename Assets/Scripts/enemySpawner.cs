using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrfab1;



    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrfab1, new Vector3(Random.Range(-10f, 10f), Random.Range(-3f, 3f), 0), Quaternion.identity);
    }

    
}
