﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<GameObject> tools;
    public GameObject activeTool;
    public int currentTool;
    public bool canChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("HTC_VIU_UnityAxis20") != 0 && canChange == true)
        {
            canChange = false;
            ChangeTool();
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis20") == 0 )
        {
            canChange = true;
           
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            //ChangeTool();
        }
    }
    public void ChangeTool()
    {
        tools[currentTool].active = false;
        currentTool++;
        if (currentTool >= tools.Count) { currentTool = 0; }
        tools[currentTool].active = true;

    }
}