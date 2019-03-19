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
            GameObject clone = transform.GetChild(0).gameObject;//Instantiate(gameObject, transform.position, transform.rotation) as GameObject;
            clone.layer = 9;

          
            if (possibleConnection.transform.parent.name != "ContructedObjectParent(Clone)" && possibleConnection.name != "ContructedObjectParent(Clone)")
            {
                // currentParentPiece = possibleConnection.GetComponent<LegoPiece>().currentParentPiece;
                // GetComponent<Rigidbody>().isKinematic = true;
                GameObject clone2 = Instantiate(prefabParentPiece, transform.position, transform.rotation) as GameObject;
                transform.GetChild(0).GetComponent<Collider>().enabled = true;

                clone.transform.parent = clone2.transform;
                possibleConnection.transform.GetChild(0).gameObject.layer = 9;
                possibleConnection.transform.GetChild(0).GetComponent<Collider>().enabled = true;
                possibleConnection.transform.GetChild(0).parent = clone2.transform;
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
                if (possibleConnection.name == "ContructedObjectParent(Clone)")
                {
                    transform.GetChild(0).GetComponent<Collider>().isTrigger = false;
                    transform.GetChild(0).GetComponent<Collider>().enabled = true;
                    clone.transform.parent = possibleConnection.transform;
                   
                }
                else
                {
                    transform.GetChild(0).GetComponent<Collider>().isTrigger = false;
                    transform.GetChild(0).GetComponent<Collider>().enabled = true;
                    clone.transform.parent = possibleConnection.transform.parent;
                    
                }
               
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
        }
        GetComponent<Collider>().isTrigger = false;

    }
    public void OnTriggerEnter(Collider other) { if (other.transform.tag == "Lego") { possibleConnection = other.gameObject; } }
    public void OnTriggerExit(Collider other) { if (other.gameObject == possibleConnection) { possibleConnection = null; } }

   
}
