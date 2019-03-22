﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcr : MonoBehaviour
{
    public List<GameObject> enviromentsToLoad;
    public GameObject spawnParent,visualIndicator,lastLoadedCart,activeEnviroment,oldEnviroment,blankEnviroment;
    public List<Transform> enviromentPositions;
    public Dictionary<Material, GameObject> possibleEnviroments;
    public List<Material> usedColors, unusedColors;
    public float loadTime,speed;
    public bool enableEnviromentObjects; //for when it has moved into place to avoid collisions of momentuem from the switch
    public RoomManager roomManager;
    // Start is called before the first frame update
    void Start()
    {
        possibleEnviroments = new Dictionary<Material, GameObject>();
        foreach (GameObject go in enviromentsToLoad)
        {
            possibleEnviroments.Add(go.GetComponent<Enviroment>().roomColor, go);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

        if (Vector3.Distance(activeEnviroment.transform.position, enviromentPositions[0].position) > 0)//check distance move active enviroment to centered positon
        {
            activeEnviroment.transform.position = Vector3.MoveTowards(activeEnviroment.transform.position, enviromentPositions[0].position, Time.deltaTime * speed);
            oldEnviroment.transform.position = Vector3.MoveTowards(oldEnviroment.transform.position, enviromentPositions[1].position, Time.deltaTime * speed);
            // loadTime -= Time.deltaTime;

        }
        else
        {
            if (enableEnviromentObjects == true)
            {
                enableEnviromentObjects = false;
                activeEnviroment.GetComponent<Enviroment>().SetupRoom();
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != lastLoadedCart && other.GetComponent<Cartridge>() != null)
        {
            if (other.GetComponent<Cartridge>().type == 0)
            {

                activeEnviroment.GetComponent<Enviroment>().ToggleSpawnedObjects(false);

                

                if (possibleEnviroments.ContainsKey(other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material))
                {
                    enableEnviromentObjects = true;
                    lastLoadedCart = other.gameObject;
                    other.transform.rotation = transform.rotation;
                    oldEnviroment = activeEnviroment;
                    //oldEnviroment.GetComponent<Enviroment>().ToggleSpawnedObjects(false);
                  
                    activeEnviroment = possibleEnviroments[other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material];
                    visualIndicator.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material;
                    foreach (Transform go in spawnParent.transform) { Destroy(go.gameObject); }
                }
                else
                {
                    GameObject clone = Instantiate(blankEnviroment, blankEnviroment.transform.position, blankEnviroment.transform.rotation) as GameObject;
                    clone.GetComponent<Enviroment>().SetColor(other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material);

                    //clone.GetComponent<Enviroment>().blankwall.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material;
                    possibleEnviroments.Add(other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material, clone);

                    enableEnviromentObjects = true;
                    lastLoadedCart = other.gameObject;
                    other.transform.rotation = transform.rotation;
                    oldEnviroment = activeEnviroment;
                    activeEnviroment = possibleEnviroments[other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material];
                   
                    visualIndicator.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material;
                    foreach (Transform go in spawnParent.transform) { Destroy(go.gameObject); }

                }
                roomManager.activeEnviroment = activeEnviroment.GetComponent<Enviroment>();

            }
        }
        else { if (other.GetComponent<Rigidbody>() != null) { other.GetComponent<Rigidbody>().AddForce(transform.right * Time.deltaTime * -150.0f,ForceMode.Impulse); } }
    }
}
