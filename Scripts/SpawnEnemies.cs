using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject platform;
    public GameObject enemyPlatform;
    public GameObject startPlatform;
    public int enemyBegin = 250;
    //public GameObject Enemy, directionEnemy;

    private float distance;
    private float distanceUsed;
    private void Update()
    {
        
        if (distance < transform.position.x + 20)
        {
            distance = transform.position.x + 20;
        }

        float distToGo = Mathf.Floor(f: distance - distanceUsed);

        if (distanceUsed < distance && distToGo > 4)
        {
            distanceUsed = distance;
            print(distToGo);
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = SelectEnemyToSpawn();

        float ypos = Mathf.Floor(f: Mathf.Abs(f: UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * (1 + 50 - (-2)) + (-2));
        Vector2 posToSpawnEnemy = new Vector2(x: distance, ypos);
        
        Instantiate(enemyToSpawn, posToSpawnEnemy, Quaternion.identity);
    }
    private GameObject SelectEnemyToSpawn()
    {
        if (transform.position.x - startPlatform.transform.position.x < enemyBegin) return platform;
        else
        {
            int rand = UnityEngine.Random.Range(0, 10);
            if(rand == 4 || rand == 9)
            {
                return enemyPlatform;
            }
            else
            {
                return platform;
            }
        }
    }
}


