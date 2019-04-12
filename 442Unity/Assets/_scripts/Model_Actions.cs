using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Actions : MonoBehaviour
{
    public int action;
    public GameObject gun, bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActionList()
    {
        switch (action)
        {
            case 0:
                GameObject clone = Instantiate(bullet, gun.transform.position, transform.rotation);
                clone.GetComponent<DieInTime>().timer = 2;
                break;
            case 1:

                GetComponent<Rigidbody>().AddForce( transform.forward * 10.0f * Time.deltaTime,ForceMode.Impulse);
                Debug.Log("Case 1");
                break;
            case 2:
                Debug.Log("Case 2");
                break;
            default:
                
             //  clone.GetComponent<Rigidbody>().velocity = (transform.forward + transform.position) - transform.position * clone.GetComponent<Bullet>().speed;
                Debug.Log("Default case");
                break;
        }

    }
}
