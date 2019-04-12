using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nail : MonoBehaviour
{
    public GameObject heldObject;
    public Vector3 objPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameObject roomManager = GameObject.Find("RoomManager");
        //if the roommanager exists set this spawned nail's parent to the playerSpawnedObjects for clean up when enviroment switching
        if (roomManager != null)
        {
            transform.parent = roomManager.GetComponent<RoomManager>().activeEnviroment.playerSpawnedObjects;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (heldObject.transform.position != objPosition) { heldObject.transform.position = objPosition; }
    }
    public void SetObject(GameObject nailedObject)
    {
        //object data coming from hammer on collision
        heldObject = nailedObject;
        objPosition = heldObject.transform.position;
        heldObject.transform.parent = this.transform;
    }
    public void DestroyedByHammer()
    {
        if (heldObject != null) { heldObject.transform.parent = transform.parent; heldObject.GetComponent<Rigidbody>().isKinematic = false; }
    
        Destroy(this.gameObject);
    }
}
