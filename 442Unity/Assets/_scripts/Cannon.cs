using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform barrel,cannonBase,spawnSpot, spawnParent;
    public GameObject defaultBullet,loadedBullet;
    public List<GameObject> loadedBullets;
    public bool singleShot;
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
            case 4:
                Launch(1200.0f);
                loadedBullet = null;
                break;
            case 5:
                Launch(1600.0f);
                break;
            case 6:
                Launch(2000.0f);
                break;
            default:
                Launch(1800.0f);
                break;
         }
    }

    public void Launch(float power)
    {
        GameObject clone;
        if (loadedBullets.Count > 0 )
        { 
            clone = loadedBullets[loadedBullets.Count - 1];
            clone.transform.position = spawnSpot.position;
            clone.transform.rotation = spawnSpot.rotation;
            loadedBullets.RemoveAt(loadedBullets.Count - 1);
        }
        else { clone  = Instantiate(defaultBullet, spawnSpot.position, spawnSpot.rotation) as GameObject; }
        // clone = Instantiate(bullet, spawnSpot.position, spawnSpot.rotation) as GameObject;
        clone.transform.parent = spawnParent;
        clone.GetComponent<Rigidbody>().velocity = (spawnSpot.transform.position - barrel.position).normalized * power * Time.deltaTime;
       // loadedBullet = null;
    }
    public void LoadBullet(GameObject newBullet)
    {
        loadedBullets.Insert(0,newBullet);
            }
    public void unloadBullet(GameObject newBullet)
    {
        if (loadedBullets.Contains(newBullet)) { loadedBullets.Remove(newBullet); }
       
    }
}
