using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;
    public List<Transform> spawnAreas = new List<Transform>();

    public GameObject enemy;

    public void SpawnEnemies(float numEnemiesToSpawn)
    {
        Debug.Log(numEnemiesToSpawn + " Enemies Spawing");
        foreach (Transform spawnArea in spawnAreas)
        {
            if (numEnemiesToSpawn > 0)
            {
                GameObject enemySpawn = Instantiate(enemy, spawnArea.position, Quaternion.identity);
                gamemanager.enemies.Add(enemySpawn);
                numEnemiesToSpawn--;
            }
            else
            {
                Debug.Log("All Enemies Spawned");
            }
        }
    }

}
