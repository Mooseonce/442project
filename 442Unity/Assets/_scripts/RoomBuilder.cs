using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBuilder : MonoBehaviour
{
    public GameObject itemSelectorDial,debugPrefab, debugPrefabVisual,activeVisualIndicator;
    public List<GameObject> spawnableObjects, tempSpawnableObjects;
    public int currentItemSelected;
    public bool canSpawn;
    public RoomManager roomManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
       // currentItemSelected = Mathf.FloorToInt(itemSelectorDial.transform.localEulerAngles.x / (360 / spawnableObjects.Count));
        Debug.Log( ":  Local Rot" + itemSelectorDial.transform.localEulerAngles.x + " : " + itemSelectorDial.transform.rotation.x + " : " + itemSelectorDial.transform.localRotation.x + " : " + currentItemSelected);
        //Debug.Log("Local mod:  " + Mathf.FloorToInt( itemSelectorDial.transform.localEulerAngles.x) / (360 / spawnableObjects.Count));
        if (Input.GetAxis("Vertical") != 0 )
        {
            RayForward();
            if (activeVisualIndicator != null)
            {
                activeVisualIndicator.transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            }


                if (Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.JoystickButton4)) { Destroy(activeVisualIndicator); }// right and left grip buttons
        }
        
        if (Input.GetAxis("Vertical") == 0)
        {
            if (activeVisualIndicator != null)
            {
                GameObject clone = Instantiate(spawnableObjects[currentItemSelected], activeVisualIndicator.transform.position, activeVisualIndicator.transform.rotation);
                clone.transform.parent = roomManager.activeEnviroment.playerSpawnedObjects;
                //clone.transform.LookAt(new Vector3(transform.position.x, clone.transform.position.y, transform.position.z));
                Destroy(activeVisualIndicator);

            }
            canSpawn = true;
        }

    }
    public void RayForward()
    {
        //Calculate which object to spawn based on the rotation of the dial on the in game object
        
       

       // Debug.Log("Local Rot" + currentItemSelected + " : " + currentItemSelected);
      //  Mathf.FloorToInt(itemSelectorDial.transform.localEulerAngles.x / spawnableObjects.Count);
        RaycastHit objectHit;

        if (Physics.Raycast(transform.position, transform.forward, out objectHit, 50))
        {
            if (canSpawn == false)
            {
                if (activeVisualIndicator != null)
                {
                    //activeVisualIndicator = Instantiate(debugPrefabVisual, objectHit.point, objectHit.transform.rotation);
                    activeVisualIndicator.transform.position = objectHit.point;
                   // activeVisualIndicator.transform.LookAt(new Vector3(transform.position.x, activeVisualIndicator.transform.position.y, transform.position.z));

                }
            }
            else
            {
               // currentItemSelected = Mathf.FloorToInt(itemSelectorDial.transform.localEulerAngles.x / (350 / spawnableObjects.Count ));
                currentItemSelected =  itemSelectorDial.GetComponent<Lever>().dialSetting;
                //currentItemSelected--;
                if (currentItemSelected >= spawnableObjects.Count) { currentItemSelected = spawnableObjects.Count - 1; }
                if (currentItemSelected < 0) { currentItemSelected = 0; }
                canSpawn = false;
                activeVisualIndicator = Instantiate(tempSpawnableObjects[currentItemSelected], objectHit.point, objectHit.transform.rotation);
                activeVisualIndicator.transform.LookAt(new Vector3(transform.position.x, activeVisualIndicator.transform.position.y, transform.position.z));
                // GameObject clone =  Instantiate(debugPrefab, objectHit.point, objectHit.transform.rotation);
                // clone.transform.LookAt(new Vector3(transform.position.x,clone.transform.position.y, transform.position.z));
            }
        }
    }

}
