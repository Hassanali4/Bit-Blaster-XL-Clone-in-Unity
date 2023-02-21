using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public int pointsOnPlayerDestruction;

    public bool IsSplitter = false;
    
    [SerializeField]
    private int _NoOfPrimitives = 4;

    Score score;

    Enemies enemiesScript;

    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        this.enemiesScript = gaOb.GetComponent<Enemies>();
        this.score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
    public void DestroyByPlayer()
    {
        //Debug.Log("Destroyed By the Player");
        score.RaiseScore(pointsOnPlayerDestruction);
        if (IsSplitter)
        {
            enemiesScript.SplitterDestroyed(_NoOfPrimitives,this.gameObject);
        }
        this.enemiesScript.currentEnemiesAmount--;
        Destroy(this.gameObject);        
    }

}
