﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public List<GameObject> objectToEnableOnSetup;
    public Transform colorObjs,playerSpawnedObjects; // objects to change the material of to indicate which room this is
    public GameObject blankwall;
    public Material roomColor;
    public Color idColor;
    // Start is called before the first frame update
    void Start()
    {
        if (roomColor != null)
        {
            idColor = roomColor.color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //enable room specific objects that were disable to allow the room to 'slide' into place
    public void SetupRoom()
    {
        foreach (GameObject go in objectToEnableOnSetup)
        { go.active = true; }
        ToggleSpawnedObjects(true);


    }
    public void ToggleSpawnedObjects(bool onOrOff)
    {
        playerSpawnedObjects.gameObject.active = onOrOff;
    }
    public void SetColor(Material newColor)
    {

        roomColor = newColor;
        idColor = newColor.color;
        foreach (Transform go2 in colorObjs)
        { go2.GetComponent<Renderer>().material = roomColor; }
    }
    public void SetColorId(Color newColor)
    {

        idColor = newColor;
        if (colorObjs != null)
        {
            foreach (Transform go2 in colorObjs)
            { go2.GetComponent<Renderer>().material = roomColor; }
        }
    }
}
