using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : MonoBehaviour
{

    public float shootingSpeed;
    public float bulletSpeed;
    //public float amountAmmo;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public GameObject[] multiShotSpawnPoints;

    float nextShot = 0f;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.M) && Time.time > this.nextShot)
        {
            this.ShootRepeating();
        }*/
    }
    public void ShootRepeating()
    {
        if (Time.time > this.nextShot + this.shootingSpeed)
        {
            this.nextShot = Time.time;

            foreach (GameObject spawnPoint in this.multiShotSpawnPoints)
            {
                GameObject newBullet = GameObject.Instantiate(this.playerBulletPrefab);
                newBullet.transform.position = spawnPoint.transform.position;
                newBullet.transform.parent = this.bullets.transform;

                Rigidbody2D newBulletRigidBody = newBullet.GetComponent<Rigidbody2D>();

                Vector3 dir = (spawnPoint.transform.position - this.gameObject.transform.position).normalized;

                newBulletRigidBody.AddForce(dir * this.bulletSpeed);
            }
        }
        
    }
}
