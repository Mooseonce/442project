using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform barrel,cannonBase,spawnSpot, spawnParent;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RotateCannon( int dir)
    {
         switch(dir)
        {
            case 0:
                barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + 5, 0, 0);
               // barrel.transform.Rotate(5,0,0);
                    break;
            case 1:
                barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - 5, 0, 0);
                break;
            case 2:
                cannonBase.transform.localEulerAngles = new Vector3(0, cannonBase.transform.localEulerAngles.y + 5, 0);
                break;
            case 3:
                cannonBase.transform.localEulerAngles = new Vector3(0, cannonBase.transform.localEulerAngles.y - 5, 0);
                break;
            default:
                GameObject clone = Instantiate(bullet, spawnSpot.position, spawnSpot.rotation) as GameObject;
                clone.transform.parent = spawnParent;
                clone.GetComponent<Rigidbody>().velocity = (spawnSpot.transform.position - barrel.position).normalized * 1300.0f * Time.deltaTime;
                break;
         }
    }
}
