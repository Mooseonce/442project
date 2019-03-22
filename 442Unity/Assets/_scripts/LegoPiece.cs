using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class LegoPiece : MonoBehaviour
   
{
    public GameObject currentParentPiece,prefabParentPiece,possibleConnection;//for when touching a piece it could connect to
    public int currentSizeChange, currentSizeChangeVert, maxSizeChange;
    public bool canChangeSize, canChangeSizeVert; // only grow once per axis change as to not grow out of control
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && GetComponent<Collider>().isTrigger == true) {
            int posOrNeg = (int)Mathf.Sign(Input.GetAxis("Horizontal"));
            if (canChangeSize == true && currentSizeChange !=  posOrNeg * maxSizeChange) {
                canChangeSize = false;
                if (posOrNeg == -1)
                { transform.localScale = new Vector3(transform.localScale.x / 1.1f, transform.localScale.y, transform.localScale.z / 1.1f);}
                else { transform.localScale = new Vector3(transform.localScale.x * 1.1f, transform.localScale.y, transform.localScale.z * 1.1f); }
                
                currentSizeChange += posOrNeg;
                }

        }
        else { canChangeSize = true; }

        if (Input.GetAxis("Vertical") != 0 && GetComponent<Collider>().isTrigger == true)
        {
            int posOrNeg = (int)Mathf.Sign(Input.GetAxis("Horizontal"));
            if (canChangeSizeVert == true && currentSizeChangeVert != posOrNeg * maxSizeChange)
            {
                canChangeSizeVert = false;
                if (posOrNeg == -1)
                { transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y / 1.1f, transform.localScale.z ); }
                else { transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y * 1.1f, transform.localScale.z ); }

                currentSizeChangeVert += posOrNeg;
            }

        }
        else { canChangeSizeVert = true; }
    }
    public void SetTrigger() {
        GetComponent<Collider>().isTrigger = true;
        //if (currentParentPiece != null)
        //{ currentParentPiece = null;transform.parent = null;
        //    GetComponent<Rigidbody>().isKinematic = false;
        //    if (GetComponent<FixedJoint>() != null) { Destroy(GetComponent<FixedJoint>()); }


        //        }
        //if (GetComponent<FixedJoint>() != null) { Destroy(GetComponent<FixedJoint>()); }
        //GetComponent<Collider>().isTrigger = true;
    }


    public void SetSolid() {
        if (possibleConnection != null)
        {
            if (transform.childCount > 0)
            {
                GameObject clone = transform.GetChild(0).gameObject;//Instantiate(gameObject, transform.position, transform.rotation) as GameObject;
                clone.layer = 9;
                if (possibleConnection.transform.parent != null)
                {
                    if (possibleConnection.transform.parent.name == "ContructedObjectParent(Clone)")
                    {
                        clone.transform.parent = possibleConnection.transform.parent;
                        clone.GetComponent<Collider>().isTrigger = false;
                        clone.GetComponent<Collider>().enabled = true;
                        return;
                    }
                }

                if (possibleConnection.name != "ContructedObjectParent(Clone)")
                {
                    // currentParentPiece = possibleConnection.GetComponent<LegoPiece>().currentParentPiece;
                    // GetComponent<Rigidbody>().isKinematic = true;
                    GameObject clone2 = Instantiate(prefabParentPiece, transform.position, transform.rotation) as GameObject;
                    GameObject roomManager = GameObject.Find("RoomManager");
                    if (roomManager != null)
                    {
                        clone2.transform.parent = roomManager.GetComponent<RoomManager>().activeEnviroment.playerSpawnedObjects;
                    }

                    clone.transform.parent = clone2.transform;
                    clone.GetComponent<Collider>().enabled = true;
                    if (possibleConnection.transform.childCount > 0)
                    {
                        GameObject clone3 = possibleConnection.transform.GetChild(0).gameObject;
                        clone3.transform.parent = clone2.transform;
                        clone3.gameObject.layer = 9;
                        clone3.GetComponent<Collider>().enabled = true;
                    }
                    clone2.GetComponent<Rigidbody>().useGravity = true;
                    //   Destroy(possibleConnection);
                    // Destroy(this.gameObject);
                    //possibleConnection.active = false;
                    // gameObject.active = false;

                    // gameObject.AddComponent<FixedJoint>();
                    // GetComponent<FixedJoint>().connectedBody = currentParentPieceGetComponent<Rigidbody>();
                    // GetComponent<FixedJoint>().connectedBody = currentParentPiece.GetComponent<Rigidbody>();
                }
                else
                {
                    // if (possibleConnection.name == "ContructedObjectParent(Clone)")
                    // {
                    //     transform.GetChild(0).GetComponent<Collider>().isTrigger = false;
                    //     transform.GetChild(0).GetComponent<Collider>().enabled = true;
                    //     clone.transform.parent = possibleConnection.transform;

                    // }
                    //  else
                    //{
                    clone.transform.parent = possibleConnection.transform.parent;
                    clone.GetComponent<Collider>().isTrigger = false;
                    clone.GetComponent<Collider>().enabled = true;
                   

                    // }

                    //Destroy(this.gameObject);
                    // gameObject.active = false;
                    // gameObject.AddComponent<FixedJoint>();
                    //   GetComponent<FixedJoint>().connectedBody = currentParentPiece.GetComponent<Rigidbody>();
                    // GetComponent<Rigidbody>().isKinematic = true;
                    // possibleConnection.GetComponent<Rigidbody>().isKinematic = true;
                    //  possibleConnection.AddComponent<FixedJoint>();
                    // possibleConnection.GetComponent<FixedJoint>().connectedBody = currentParentPiece.GetComponent<Rigidbody>();
                }
                GetComponent<Collider>().enabled = false;
                GetComponent<Renderer>().enabled = false;
                //  Destroy(this.gameObject);

            }
        }
        GetComponent<Collider>().isTrigger = false;

    }
    public void OnTriggerEnter(Collider other) { if (other.transform.tag == "Lego" && GetComponent<Collider>().isTrigger == true) { possibleConnection = other.gameObject; } }
    public void OnTriggerExit(Collider other) { if (other.gameObject == possibleConnection) { possibleConnection = null; } }

   
}
