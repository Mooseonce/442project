using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool on,debugbool;
    public Material onColor, offColor;
    public GameObject ofOffLightObject,grabberHandle,visualHandle; //has grab script, visual handle is jointed to this
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debugbool == true) { debugbool = false; HandleReleased(); }
    }
    public void HandleReleased()
    {
        if (grabberHandle.transform.localPosition.z < 0.4f) {
            on = false;
            ofOffLightObject.GetComponent<Renderer>().material = offColor;
            grabberHandle.GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, -0.2f);
        }
        if (grabberHandle.transform.localPosition.z > 0.5f)
        {
            
            on = true;
            ofOffLightObject.GetComponent<Renderer>().material = onColor;
            grabberHandle.GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0,0,-0.7f);

        }
    }
}
