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
    public void OnCollisionEnter(Collision col)
    {
        if (timer <= 0)
        {
            timer = 0.2f;

            if (col.transform.tag == "Nail")
            {
                if (col.gameObject.GetComponent<Nail>().heldObject != null)
                {
                    GameObject other = col.gameObject.GetComponent<Nail>().heldObject;

                    other.GetComponent<Rigidbody>().isKinematic = false;
                }
                Destroy(col.gameObject);
            }
            else
            {
                if (col.gameObject.GetComponent<Rigidbody>() != null)
                {
                    col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    GameObject clone = Instantiate(nail, transform.position, transform.rotation) as GameObject;
                    nail.GetComponent<Nail>().heldObject = col.gameObject;
                }
            }


                // else { col.gameObject.GetComponent<Rigidbody>().isKinematic = true; }
            
        }
    }
}
