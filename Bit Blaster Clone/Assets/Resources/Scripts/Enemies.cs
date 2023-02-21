using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject[] spawnAreas;
    public int maxEnemiesAmountOnStart;
    public int extraEnemiesPerXTotalEnemies;
    public int currentEnemiesAmount = 0;
    public int totalEnemiesAmount = 0;

    int maxEnemies;
    // Start is called before the first frame update
    void Update()
    {

        this.maxEnemies = this.maxEnemiesAmountOnStart + this.totalEnemiesAmount / this.extraEnemiesPerXTotalEnemies;

        if (this.currentEnemiesAmount < this.maxEnemies)
        {
            this.SpawnRandomEnemy();
        }
        
    }

    public void SplitterDestroyed(int NoPrimitive , GameObject currentSpawnPos)
    {
        CreateEnemy enemy;

        for (int i = 0; i < NoPrimitive; i++)
        {
            enemy = CreateEnemy.GetNewPrimitive();
            this.SetupNewEnemy(enemy, currentSpawnPos);
            this.currentEnemiesAmount++;
            this.totalEnemiesAmount++;
        }
            
    }

    // Update is called once per frame
    public void SpawnRandomEnemy()
    {
        CreateEnemy enemy;

        float v = Random.value;

        if (v >= 0.5)
        {
            enemy = CreateEnemy.GetNewPrimitive();
        }
        else if (v >= 0.2)
        {
            enemy = CreateEnemy.GetNewSplitter();
        }
        else
        {
            enemy = CreateEnemy.GetNewShooter();
        }
        this.SetupNewEnemy(enemy);

        this.currentEnemiesAmount++;
        this.totalEnemiesAmount++;
    }
    public void SetupNewEnemy(CreateEnemy enemy, GameObject spawnArea = null)
    {
        if (spawnArea == null)
        {
            int i = Random.Range(0,this.spawnAreas.Length);
            spawnArea = this.spawnAreas[i];
        }
        Vector3 spawnPosition = GetSpawnPosition(spawnArea);

        enemy.transform.position = spawnPosition;
        enemy.transform.parent = this.transform;

        EnemyMovementController enemyMovementController = enemy.movementController;

        if (spawnArea.name == "Left")
        {
            enemyMovementController.movementdirection = Vector3.right;
        }
        else if (spawnArea.name == "Right")
        {
            enemyMovementController.movementdirection = Vector3.left;
        }
        else if (spawnArea.name == "Top")
        {
            enemyMovementController.movementdirection = Vector3.down;
        }
        else if (spawnArea.name == "Down")
        {
            enemyMovementController.movementdirection = Vector3.up;
        }

    }
    Vector3 GetSpawnPosition(GameObject spawnArea)
    {
        Vector3 scale = spawnArea.transform.localScale;

        float x = spawnArea.transform.position.x + Random.Range(-scale.x / 2, scale.x / 2);
        float y = spawnArea.transform.position.y + Random.Range(-scale.y / 2, scale.y / 2);

        Vector3 location = new Vector3(x, y, 0);

        return location;
    }
}
