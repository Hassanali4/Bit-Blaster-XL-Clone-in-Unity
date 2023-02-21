using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpController : MonoBehaviour
{
    public float basicDuration;

    public bool powerUpActive = true;

    public MultiShot multishot;

    float activeUntilTime = 0;

    string powerUpType = "multiShot";

    public GameObject laser;

    public GameObject berserk;

    //float _lesstimecount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        ActivateBerserk();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (powerUpActive && Time.time < this.activeUntilTime)
        {
            if (this.powerUpType == "multishot")
            {
                this.multishot.ShootRepeating();
            }
            else if (this.powerUpType == "laser")
            {
                this.laser.SetActive(true);
            }
            else if (this.powerUpType == "berserk")
            {
                this.berserk.SetActive(true);
            }
        }
        else
        {
            this.powerUpType = null;
            this.powerUpActive = false;
        }
        if (this.powerUpType != "laser")
        {
            this.laser.SetActive(false);
        }
        if (this.powerUpType != "berserk")
        {
            this.berserk.SetActive(false);
        }
    }

    public void ActivateMultiShot()
    {
        this.powerUpActive = true;
        this.powerUpType = "multishot";
        this.activeUntilTime = Time.time + this.basicDuration;
    }
    public void ActivateLaser()
    {
        this.powerUpActive = true;
        this.powerUpType = "laser";
        this.activeUntilTime = Time.time + this.basicDuration;
    }
    public void ActivateBerserk()
    {
        this.powerUpActive = true;
        this.powerUpType = "berserk";
        this.activeUntilTime = Time.time + this.basicDuration;
    }
}
