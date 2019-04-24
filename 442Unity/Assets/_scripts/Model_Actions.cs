using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Actions : MonoBehaviour
{
    public int action;
    public float timer,timerCycle;
    public bool toggleType, isOn;
    public GameObject gun, bullet,wingleft,wingright;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ToggleActionList();
                timer = timerCycle;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) { ActionList(); }
    }
    public void ActionList()
    {
        switch (action)
        {
            case 0:
                GameObject clone = Instantiate(bullet, gun.transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().AddForce(gun.transform.up * 200.0f * Time.deltaTime,ForceMode.Impulse);
                clone.GetComponent<DieInTime>().timer = 5;
                break;
            case 1:

                GetComponent<Rigidbody>().AddForce( transform.forward * 10.0f * Time.deltaTime,ForceMode.Impulse);
      
                break;
            case 2:
                wingleft.GetComponent<Rigidbody>().AddForce(transform.forward * -100.0f * Time.deltaTime, ForceMode.Impulse);
                wingright.GetComponent<Rigidbody>().AddForce(transform.forward * -100.0f * Time.deltaTime, ForceMode.Impulse);
                
                break;
            case 3:
                if (isOn == true) { isOn = false; GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = true; } else { timer = timerCycle; isOn = true; }
                break;
            default:
                Debug.Log("Default case");
                break;
        }

    }
    public void ToggleActionList()
    {
        switch (action)
        {
            case 0:
                GameObject clone = Instantiate(bullet, gun.transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().AddForce(gun.transform.forward * 10.0f * Time.deltaTime);
                clone.GetComponent<DieInTime>().timer = 5;
                break;
            case 1:

                GetComponent<Rigidbody>().AddForce(transform.forward * 10.0f * Time.deltaTime, ForceMode.Impulse);
              
                break;
            case 2:
                wingleft.GetComponent<Rigidbody>().AddForce(transform.forward * -100.0f * Time.deltaTime, ForceMode.Impulse);
                wingright.GetComponent<Rigidbody>().AddForce(transform.forward * -100.0f * Time.deltaTime, ForceMode.Impulse);
                GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = false;
                break;
            case 3:
                wingleft.GetComponent<Rigidbody>().AddForce(transform.forward * -100.0f * Time.deltaTime, ForceMode.Impulse);
                wingright.GetComponent<Rigidbody>().AddForce(transform.forward * -100.0f * Time.deltaTime, ForceMode.Impulse);
                GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = false;
                break;
            default:

                Debug.Log("Default case");
                break;
        }
    }

}
