using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InnerBorder")
        {
            Destroy(this.gameObject);
        }else if (collision.tag == "EnemyCollider")
        {
            EnemyDestroyController enemyDestroyController = collision.transform.parent.GetComponent<EnemyDestroyController>();
            enemyDestroyController.DestroyByPlayer();

            Destroy(this.gameObject); 
        }
    }
}
