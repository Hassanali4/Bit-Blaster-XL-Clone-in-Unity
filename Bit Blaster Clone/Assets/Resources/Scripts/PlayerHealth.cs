using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int amountShields;
    public GameObject shipSprite;
    public float invincibleTime;
    public GameObject[] shipShields;

    bool invincible = false;

    private IEnumerable coroutine;

    //Take Damage
    public void TakeDamage()
    {
        if (!this.invincible)
            this.amountShields--;
        if (this.amountShields < 0)
        {
            //destroy the Ship
            this.DestroytheShip();
            Debug.Log("Destroy the ship");
        }
        else
        {   
            //bling bling invcibility
            StartCoroutine(InvincibleAfterDamage());
            Debug.Log("Start Invinciblity");
        }
    }
    //Destroy Ship
    public void DestroytheShip()
    {
        Destroy(this.gameObject);
    }
    //bling bling invcibility

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Triggered in Player health");
    }

    public IEnumerator InvincibleAfterDamage()
    {
        this.invincible = true;
        //Debug.Log("Invincible");

        for (int i = 0; i < 4; i++)
        {
            this.shipSprite.SetActive(false);
            yield return new WaitForSeconds(0.10f);
            this.shipSprite.SetActive(true);
            yield return new WaitForSeconds(0.10f);

        }

        this.invincible = false;
        //Debug.Log("Not Invincible");
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < this.amountShields)
            {
                this.shipShields[i].SetActive(true);
            }
            else
            {
                this.shipShields[i].SetActive(false);
            }
        }
    }
}
