using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyCollider")
        {
            EnemyDestroyController edc = collision.transform.parent.GetComponent<EnemyDestroyController>();
            edc.DestroyByPlayer();
        }
    }
}
