using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcr : MonoBehaviour
{
    public List<GameObject> enviromentsToLoad;
    public GameObject spawnParent,visualIndicator,lastLoadedCart,activeEnviroment,oldEnviroment;
    public List<Transform> enviromentPositions;
    public float loadTime,speed;
    public bool enableEnviromentObjects; //for when it has moved into place to avoid collisions of momentuem from the switch
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

        if (Vector3.Distance(activeEnviroment.transform.position, enviromentPositions[0].position) > 0)//check distance move active enviroment to centered positon
        {
            activeEnviroment.transform.position = Vector3.MoveTowards(activeEnviroment.transform.position,enviromentPositions[0].position, Time.deltaTime * speed * 1.2f);
            oldEnviroment.transform.position = Vector3.MoveTowards(oldEnviroment.transform.position, enviromentPositions[1].position, Time.deltaTime * speed);
            // loadTime -= Time.deltaTime;
           
        }
        if (Vector3.Distance(activeEnviroment.transform.position, enviromentPositions[0].position) == 0 && enableEnviromentObjects == true)
        {
            enableEnviromentObjects = false;
            activeEnviroment.GetComponent<Enviroment>().SetupRoom();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != lastLoadedCart && other.GetComponent<Cartridge>() != null)
        {
            if (other.GetComponent<Cartridge>().type == 0)//0 hoops with launcher,1: basketball, 2: launcher with cubes to knockover
            { if (other.GetComponent<Cartridge>().value < enviromentsToLoad.Count)
                {
                    enableEnviromentObjects = true;
                    lastLoadedCart = other.gameObject;
                    other.transform.rotation = transform.rotation;
                    oldEnviroment = activeEnviroment;
                    activeEnviroment = enviromentsToLoad[other.GetComponent<Cartridge>().value];
                    visualIndicator.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().color;
                    foreach (Transform go in spawnParent.transform) { Destroy(go.gameObject); }
                }

            }
        }
    }
}
