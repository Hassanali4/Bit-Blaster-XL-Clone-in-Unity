using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float duration;
    float killTime;

    public float BlinkingTime;
    bool Isblinking = false;

    public string collectableType;

    SpriteRenderer collectableSprite;
    // Start is called before the first frame update
    void Start()
    {
        this.killTime = Time.time + duration;
        this.collectableSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Time.time > this.killTime - this.BlinkingTime) && Isblinking)
        {
            StartCoroutine(Blink());
            this.Isblinking = true;
        }
        if (Time.time > killTime)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Blink()
    {
        this.Isblinking = true;
        for (int i = 0; i < 4; i++)
        {
            this.collectableSprite.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            this.collectableSprite.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);

        }
    } // IEnumerator

    public static Collectable CreateAmmo()
    {
        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefab/Ammo"));
        return ammo.GetComponent<Collectable>();
    }
    public static Collectable CreateBerserkMode()
    {
        GameObject berserk = (GameObject)Instantiate(Resources.Load("Prefab/Berserk"));
        return berserk.GetComponent<Collectable>();
    }
    public static Collectable CreateBomb()
    {
        GameObject bomb = (GameObject)Instantiate(Resources.Load("Prefab/Bomb"));
        return bomb.GetComponent<Collectable>();
    }public static Collectable CreateShield()
    {
        GameObject shield = (GameObject)Instantiate(Resources.Load("Prefab/Shield"));
        return shield.GetComponent<Collectable>();
    }public static Collectable CreateLaser()
    {
        GameObject laser = (GameObject)Instantiate(Resources.Load("Prefab/Laser"));
        return laser.GetComponent<Collectable>();
    }public static Collectable CreateMultiShot()
    {
        GameObject multiShot = (GameObject)Instantiate(Resources.Load("Prefab/MultiShot"));
        return multiShot.GetComponent<Collectable>();
    }
}
