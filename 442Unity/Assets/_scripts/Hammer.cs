using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject nail;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
    }
    public void PickedUp()
    { timer = 0.5f; }
    public void Dropped()
    { timer = -1; }
    public void OnCollisionEnter(Collision col)
    {
        if (timer <= 0 && timer != -1)
        {
            timer = 0.5f;

           
                if (col.gameObject.GetComponent<Rigidbody>() != null)
                {
                    if (col.gameObject.GetComponent<Rigidbody>().isKinematic == false)
                    {
                        col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        GameObject clone = Instantiate(nail, transform.position, transform.parent.rotation) as GameObject;
                        clone.GetComponent<Nail>().SetObject(col.gameObject);
                    }
                }
                //else
                //{
                //    if (col.gameObject.GetComponent<Rigidbody>() != null)
                //    {
                //        if (col.gameObject.GetComponent<Rigidbody>().isKinematic == false)
                //        {
                //            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //            GameObject clone = Instantiate(nail, transform.position, transform.parent.rotation) as GameObject;
                //            clone.GetComponent<Nail>().heldObject = col.gameObject;
                //        }
                //    }
                //}
            


                // else { col.gameObject.GetComponent<Rigidbody>().isKinematic = true; }
            
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (timer <= 0 && timer != -1)
        {
            timer = 0.5f;

            if (col.transform.tag == "Nail")
            {
                if (col.gameObject.GetComponent<Nail>().heldObject != null)
                {
                    col.gameObject.GetComponent<Nail>().DestroyedByHammer();
                    //GameObject other = col.gameObject.GetComponent<Nail>().heldObject;

                   // other.GetComponent<Rigidbody>().isKinematic = false;


                }
               // Destroy(col.gameObject);
            }
        }
    }
}
