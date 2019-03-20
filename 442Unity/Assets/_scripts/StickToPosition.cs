using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPosition : MonoBehaviour
{
    public Transform sitSpot; //each frame move to this transform's positon
    public GameObject objectToMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectToMove.transform.position = sitSpot.position;
        objectToMove.transform.rotation = sitSpot.rotation;
    }
}
