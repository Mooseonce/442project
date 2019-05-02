using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Piece : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mainHubPiece, canAttach, attached;
    public int type;
    public GameObject mainShip, connectionPoint, colorIndicator, debugObject, bullet;
    public List<GameObject> myConnections;
   // public HTC.UnityPlugin.Vive.BasicGrabbable bg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  if (attached == true && bg.enabled == true) { bg.enabled = false; }
    }
    public void FireLaser()
    {
      //  GameObject clone = Instantiate(bullet, transform.forward + transform.position, transform.rotation);
      //  clone.GetComponent<Rigidbody>().velocity = (transform.forward + transform.position) - transform.position * clone.GetComponent<Bullet>().speed;

    }
    public void PickedUp()
    {
        if (attached != true)
        {
            canAttach = true;
            GetComponent<Rigidbody>().isKinematic = false;
            //  transform.parent = null;
            if (GetComponent<FixedJoint>() != null) { Destroy(GetComponent<FixedJoint>()); }
            if (attached == true) { attached = false; mainShip.GetComponent<ModelMainBody>().RemovePiece(type, this.gameObject); }
        }
    }
    public void LetGo()
    {
        if (connectionPoint != null && canAttach == true && connectionPoint.transform.parent.GetComponent<Model_Piece>().attached == true)
        {
           // GetComponent<Rigidbody>().isKinematic = true;
           // transform.parent = mainShip.transform;
            attached = true;
            mainShip = connectionPoint.transform.parent.GetComponent<Model_Piece>().mainShip;
                  mainShip.GetComponent<ModelMainBody>().AddPiece(type, this.gameObject);
            this.gameObject.AddComponent(typeof(FixedJoint)) ; GetComponent<FixedJoint>().connectedBody = connectionPoint.transform.parent.GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().useGravity = false;// mainShip.GetComponent<Rigidbody>().useGravity;
        }
        canAttach = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Connection" && canAttach == true)
        { connectionPoint = other.gameObject; }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Connection")
        { connectionPoint = null; }
    }
    public Color GetColorId()
    { return colorIndicator.GetComponent<Renderer>().material.color; }

}