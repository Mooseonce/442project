using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    public string objectTypeToDestroy;
    public bool loader;
    public Cannon mortorToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (loader == true && mortorToLoad != null && other.GetComponent<Rigidbody>() != null)
        { mortorToLoad.LoadBullet(other.gameObject); }
        else
        {
            if (other.tag == objectTypeToDestroy) { Destroy(other.gameObject); }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (loader == true && mortorToLoad != null && other.GetComponent<Rigidbody>() != null)
        { mortorToLoad.unloadBullet(other.gameObject); }
       
    }
}
