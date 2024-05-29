using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -100)
        {
            Destroy(gameObject);
        }
    }
}

