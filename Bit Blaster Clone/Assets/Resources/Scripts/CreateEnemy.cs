using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public EnemyMovementController movementController;

    public static CreateEnemy GetNewPrimitive()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Enemies/EnemyPrimitive"));
        return enemy.GetComponent<CreateEnemy>();
    }
    public static CreateEnemy GetNewSplitter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Enemies/EnemyPrimitiveSplitter"));
        return enemy.GetComponent<CreateEnemy>();
    }
    public static CreateEnemy GetNewShooter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Enemies/EnemyShooter"));
        return enemy.GetComponent<CreateEnemy>();
    }
}
