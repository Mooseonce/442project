﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInTime : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != -1)
        { timer -= Time.deltaTime;
            if (timer <= 0) { Destroy(this.gameObject); }
        }
    }
}
