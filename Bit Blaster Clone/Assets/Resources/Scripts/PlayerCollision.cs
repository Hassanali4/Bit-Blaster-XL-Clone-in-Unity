using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        this.player = this.transform.parent.gameObject;
        this.playerhealth = this.player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InneBorder")
        {
            print("Destroyed the ship");
            this.playerhealth.DestroytheShip();
        }
        else if (collision.tag == "EnemyCollider")
        {
            print("touched Enemy");
            this.playerhealth.TakeDamage();
        }
        else if (collision.tag == "Collectable")
        {
            //TODO : add Collectables
        }
    }
}
