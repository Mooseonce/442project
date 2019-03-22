using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBuilder : MonoBehaviour
{
    public GameObject itemSelectorDial,debugPrefab, debugPrefabVisual,activeVisualIndicator;
    public List<GameObject> spawnableObjects;
    public bool canSpawn;
    public RoomManager roomManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Local mod:  " + Mathf.FloorToInt( itemSelectorDial.transform.localEulerAngles.x) / (360 / spawnableObjects.Count));
        if (Input.GetAxis("Horizontal") != 0 )
        {
            RayForward();
        }
        
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (activeVisualIndicator != null)
            {
                GameObject clone = Instantiate(debugPrefab, activeVisualIndicator.transform.position, activeVisualIndicator.transform.rotation);
                clone.transform.parent = roomManager.activeEnviroment.playerSpawnedObjects;
                //clone.transform.LookAt(new Vector3(transform.position.x, clone.transform.position.y, transform.position.z));
                Destroy(activeVisualIndicator);

            }
            canSpawn = true;
        }

    }
    public void RayForward()
    {
        int tempint = Mathf.FloorToInt(  (360 / spawnableObjects.Count) % itemSelectorDial.transform.localEulerAngles.x);
        Debug.Log("Local Rot" + tempint + " : " + tempint);
        Mathf.FloorToInt(itemSelectorDial.transform.localEulerAngles.x / spawnableObjects.Count);
        RaycastHit objectHit;

        if (Physics.Raycast(transform.position, transform.forward, out objectHit, 50))
        {
            if (canSpawn == false)
            {
                if (activeVisualIndicator != null)
                {
                    //activeVisualIndicator = Instantiate(debugPrefabVisual, objectHit.point, objectHit.transform.rotation);
                    activeVisualIndicator.transform.position = objectHit.point;
                    activeVisualIndicator.transform.LookAt(new Vector3(transform.position.x, activeVisualIndicator.transform.position.y, transform.position.z));

                }
            }
            else
            {
                canSpawn = false;
                activeVisualIndicator = Instantiate(debugPrefabVisual, objectHit.point, objectHit.transform.rotation);
                activeVisualIndicator.transform.LookAt(new Vector3(transform.position.x, activeVisualIndicator.transform.position.y, transform.position.z));
                // GameObject clone =  Instantiate(debugPrefab, objectHit.point, objectHit.transform.rotation);
                // clone.transform.LookAt(new Vector3(transform.position.x,clone.transform.position.y, transform.position.z));
            }
        }
    }

}
