﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBrushTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += 0.01f*Vector3.up;
    }
}
