using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public SpriteRenderer background;

    void Start()
    {
        float Orthosize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }


}   