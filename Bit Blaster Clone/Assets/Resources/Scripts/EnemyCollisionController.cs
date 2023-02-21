using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    Enemies enemiesScript;
    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        this.enemiesScript = gaOb.GetComponent<Enemies>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OuterBorder")
        {
            this.enemiesScript.currentEnemiesAmount--;
            Destroy(this.transform.parent.gameObject);
        }
    }
}
