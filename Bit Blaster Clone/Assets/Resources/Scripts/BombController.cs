using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public int amountBombs;

    public GameObject[] bombSprites;
    public GameObject enemiesGaOb;
    public GameObject bulletsGaOb;

    void Start()
    {
        int startingNukesAmount = 5;
        this.amountBombs = startingNukesAmount;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //print("Nuking");
            this.IgniteNuke();
        }
    }

    void IgniteNuke()
    {
        if (this.amountBombs > 0)
        {
            foreach (Transform enemy in this.enemiesGaOb.transform)
            {
                EnemyDestroyController enemyDestroyController = enemy.GetComponent<EnemyDestroyController>();
                enemyDestroyController.DestroyByPlayer();
            }
            foreach (Transform enemyBullet in this.bulletsGaOb.transform)
            {
                Destroy(enemyBullet.gameObject);
            }

            this.amountBombs--;
        }   
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < this.amountBombs)
            {
                this.bombSprites[i].SetActive(true);
            }else
            {
                this.bombSprites[i].SetActive(false);
            }
        }
    }

}
