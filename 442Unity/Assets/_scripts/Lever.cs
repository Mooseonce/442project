using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool on, debugbool;
    public Material onColor, offColor;
    public GameObject objectToSendMessage,ofOffLightObject, grabberHandle, visualHandle,selectedLocObj,colorIndicator; //has grab script, visual handle is jointed to this
    public List<GameObject> selectorNotches;
    public int dialSetting,actiontype;//action type: what object this level interacts with
    public float distanceToCheck; //how far the lever is pulled to register as a valid pull
    public string messageTosend;
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
       // if (grabberHandle.transform.localPosition.z < 0.4f)
       // {
         //   on = false;
          //  ofOffLightObject.GetComponent<Renderer>().material = offColor;
          //  grabberHandle.GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, -0.2f);
       // }
        if (Mathf.Abs(grabberHandle.transform.localPosition.z) > distanceToCheck)
        {

            // on = true;
            // ofOffLightObject.GetComponent<Renderer>().material = onColor;
            // grabberHandle.GetComponent<ConfigurableJoint>().targetPosition = new Vector3(0, 0, -0.7f);
            if (actiontype == 1)//1 for sending colors to the model parent
            { objectToSendMessage.SendMessage(messageTosend, colorIndicator.GetComponent<Renderer>().material.color); }
            else if (actiontype == 2)
            { objectToSendMessage.GetComponent<ModelManager>().ActivatePiecesToggleOnWithValue(colorIndicator.GetComponent<Renderer>().material.color, grabberHandle.transform.localPosition.z); } else
            { objectToSendMessage.SendMessage(messageTosend); }

        }
    }
    public void DialReleased()
    {
        int tempint = 0;
        int selectedInt = 0;
        float tempfloat = 1.0f;
        foreach (GameObject go in selectorNotches)
        { if (Vector3.Distance(go.transform.position, selectedLocObj.transform.position) < tempfloat)
            { tempfloat = Vector3.Distance(go.transform.position, selectedLocObj.transform.position); selectedInt = tempint; }
            tempint++;
         }
        dialSetting = selectedInt;
    }
}
