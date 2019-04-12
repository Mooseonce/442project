using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vcr : MonoBehaviour 
{
    public List<GameObject> enviromentsToLoad;
    public GameObject spawnParent,visualIndicator,lastLoadedCart,activeEnviroment,oldEnviroment,blankEnviroment;
    public List<Transform> enviromentPositions;
    public Dictionary<Color, GameObject> possibleEnviroments;
    public List<Material> usedColors, unusedColors;
    public float loadTime,speed;
    public bool enableEnviromentObjects; //for when it has moved into place to avoid collisions of momentuem from the switch
    public RoomManager roomManager;
    // Start is called before the first frame update
    void Start()
    {
        possibleEnviroments = new Dictionary<Color, GameObject>();
        if (enviromentsToLoad != null)
        {
            foreach (GameObject go in enviromentsToLoad)
            {
                possibleEnviroments.Add(go.GetComponent<Enviroment>().idColor, go);

            }
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
        //check that the collision is a cartridge 
        if ( other.GetComponent<Cartridge>() != null && other.gameObject != lastLoadedCart)
        {
            if (other.GetComponent<Cartridge>().type == 0)
            {
                activeEnviroment.GetComponent<Enviroment>().ToggleSpawnedObjects(false);
                visualIndicator.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material;
                other.GetComponent<Cartridge>().idColor = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material.color;
                foreach (Transform go in spawnParent.transform) { Destroy(go.gameObject); }
                ChangeEnviroment(other.gameObject);

            }
        }
        else { if (other.GetComponent<Rigidbody>() != null) { other.GetComponent<Rigidbody>().AddForce(transform.right * Time.deltaTime * -150.0f,ForceMode.Impulse); } }
    }

    public void ChangeEnviroment(GameObject other)
    {
        //check  if the cart loaded is different than the previous one.
        if (other.gameObject != lastLoadedCart)
        {

           



            if (possibleEnviroments.ContainsKey(other.GetComponent<Cartridge>().getIdColor()))
            {
                Debug.Log("old enviroment : " + other.GetComponent<Cartridge>().getIdColor());

                enableEnviromentObjects = true;
                lastLoadedCart = other;
                other.transform.rotation = transform.rotation;
                oldEnviroment = activeEnviroment;
                //oldEnviroment.GetComponent<Enviroment>().ToggleSpawnedObjects(false);

                activeEnviroment = possibleEnviroments[other.GetComponent<Cartridge>().getIdColor()];


                
               
            }
            else
            {
                Debug.Log("new enviroment: " + other.GetComponent<Cartridge>().getIdColor());
                if (blankEnviroment != null)
                {
                    GameObject clone = Instantiate(blankEnviroment, blankEnviroment.transform.position, blankEnviroment.transform.rotation) as GameObject;
                    clone.GetComponent<Enviroment>().SetColor(other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material);
                    possibleEnviroments.Add(other.GetComponent<Cartridge>().getIdColor(), clone);
                }
                //clone.GetComponent<Enviroment>().blankwall.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material;
                // possibleEnviroments.Add(other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material.color, clone);

                enableEnviromentObjects = true;
                lastLoadedCart = other;
                other.transform.rotation = transform.rotation;
                oldEnviroment = activeEnviroment;
                activeEnviroment = possibleEnviroments[other.GetComponent<Cartridge>().getIdColor()];

                visualIndicator.GetComponent<Renderer>().material = other.GetComponent<Cartridge>().colorIndicator.GetComponent<Renderer>().material;
               // foreach (Transform go in spawnParent.transform) { Destroy(go.gameObject); }

            }
            if (roomManager != null) { roomManager.activeEnviroment = activeEnviroment.GetComponent<Enviroment>(); }
           
        }
    }
    public void AddToEnviromentList(Color colorId,GameObject newEnviroment)
    {
        if (possibleEnviroments == null)
        { possibleEnviroments = new Dictionary<Color, GameObject>(); }
        possibleEnviroments.Add(colorId, newEnviroment);
    }
    public GameObject GetActiveEnviroment()
    { return activeEnviroment; }
}
