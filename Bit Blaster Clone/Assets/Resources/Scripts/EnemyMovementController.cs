using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 movementdirection;

    public float movementSpeed;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.Translate(this.movementdirection * this.movementSpeed * Time.deltaTime);  
    }
}
