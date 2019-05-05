using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Actions : MonoBehaviour
{
    public int action;
    public float timer, timerCycle, power, levelValue;//
    public bool toggleType, isOn;
    public GameObject gun, bullet, wingleft, wingright, movablePiece;
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
        //  if (Input.GetKeyDown(KeyCode.A)) { ActionList(); }
    }
    public void ToggleOnOff()
    {
        if (isOn == true) { isOn = false; }
        else
        { timer = timerCycle; isOn = true; }
    }

    public void TurnOn()
    {
        timer = 0; isOn = true;
    }
    public void settogglepower(float newval)
    {
        if (newval == 0) { levelValue = 1.0f; } else { levelValue = Mathf.Sign(newval) * (1 + newval) ; }
    }


    public void ActionList()
    {
        switch (action)
        {
            case 0:
                GameObject clone = Instantiate(bullet, gun.transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().AddForce(gun.transform.up * power * Time.deltaTime,ForceMode.Impulse);
                clone.GetComponent<DieInTime>().timer = 5;
                break;
            case 1:

                GetComponent<Rigidbody>().AddForce( ((gun.transform.position - transform.position).normalized) * 10.0f * Time.deltaTime,ForceMode.Impulse);
      
                break;
            case 2:
                wingleft.GetComponent<Rigidbody>().AddForce(transform.forward * -power * Time.deltaTime, ForceMode.Impulse);
                wingright.GetComponent<Rigidbody>().AddForce(transform.forward * -power * Time.deltaTime, ForceMode.Impulse);
                
                break;
            case 3:
             //   GetComponent<Model_Piece>().mainShip.
                    GetComponent<Rigidbody>().AddForce(Vector3.up * power * Time.deltaTime);
               // if (isOn == true) { isOn = false; GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = true; } else { timer = timerCycle; isOn = true; GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = false; }
                break;
            case 4:
                movablePiece.GetComponent<Rigidbody>().AddTorque(transform.right * power * Time.deltaTime);
                //if (isOn == true) { isOn = false;  } else { timer = timerCycle; isOn = true; movablePiece.GetComponent<Rigidbody>().AddTorque(transform.right * power * Time.deltaTime); }
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
                clone.GetComponent<Rigidbody>().AddForce(gun.transform.forward * power * levelValue * Time.deltaTime);
                clone.GetComponent<DieInTime>().timer = 5;
                break;
            case 1:

                GetComponent<Rigidbody>().AddForce(transform.forward * power * levelValue * Time.deltaTime, ForceMode.Impulse);
              
                break;
            case 2:
                wingleft.GetComponent<Rigidbody>().AddForce(transform.forward * -power * Time.deltaTime, ForceMode.Impulse);
                wingright.GetComponent<Rigidbody>().AddForce(transform.forward * -power * Time.deltaTime, ForceMode.Impulse);
                GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = false;
                break;
            case 3:
                // wingleft.GetComponent<Rigidbody>().AddForce(transform.forward * -power * levelValue * Time.deltaTime, ForceMode.Impulse);
                wingright.GetComponent<Rigidbody>().AddForce(transform.forward * -power * levelValue * Time.deltaTime, ForceMode.Impulse);

                //GetComponent<Model_Piece>().mainShip.
                    GetComponent<Rigidbody>().AddForce(Vector3.up * power * levelValue * Time.deltaTime,ForceMode.Impulse);
                GetComponent<Model_Piece>().mainShip.GetComponent<Rigidbody>().useGravity = false;
                break;
            case 4:
                movablePiece.GetComponent<Rigidbody>().AddTorque(transform.right * power * levelValue * Time.deltaTime,ForceMode.Impulse);
                break;
            default:

                Debug.Log("Default case");
                break;
        }
    }

}
