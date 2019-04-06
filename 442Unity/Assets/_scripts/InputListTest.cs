using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    



    void Update()
    {
        // Debug.Log("1: " + Input.GetAxis("HTC_VIU_UnityAxis1") + " 2: " + Input.GetAxis("HTC_VIU_UnityAxis2") + " 4: " + Input.GetAxis("HTC_VIU_UnityAxis4") + " 5: " + Input.GetAxis("HTC_VIU_UnityAxis5"));
        //26 left hand 27 right hand isolated from 3rd axis
        // 1 left hort 4 RIGHT hort
        // 2 left vert 5 right vert




        //axis 1 2 left trach pad
        //axis 4 5 right track pad
        //axis 3 trigger
        // 11 left grip 12 right grip
        if (Input.GetAxis("HTC_VIU_UnityAxis1") != 0)
        {

            Debug.Log("HTC_VIU_UnityAxis1");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis2") != 0)
        {

            Debug.Log("HTC_VIU_UnityAxis2");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis3") != 0)
        {

            Debug.Log("HTC_VIU_UnityAxis3");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis4") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis4");
        }

        if (Input.GetAxis("HTC_VIU_UnityAxis5") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis5");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis7") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis7");

        }
        if (Input.GetAxis("HTC_VIU_UnityAxis6") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis6");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis12") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis12");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis11") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis11");
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("vert");
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Horizontal");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis8") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis8");

        }
        if (Input.GetAxis("HTC_VIU_UnityAxis9") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis9");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis13") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis13");
        }

        if (Input.GetAxis("HTC_VIU_UnityAxis14") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis14");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis10") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis10");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis15") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis15");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis16") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis16");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis17") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis17");
        }
        if (Input.GetAxis("HTC_VIU_UnityAxis18") != 0)
        {
            Debug.Log("HTC_VIU_UnityAxis18");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            Debug.Log("b8");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Debug.Log("b7");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Debug.Log("b6");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Debug.Log("b5");

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            Debug.Log("b4");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("b3");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("b2");

        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("b1");
        }


        //if (focusOn == true)
        //{ focusing(); }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    rayCheck();
        //    leftability();
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    rightability();
        //    if (grabbedEarth != null && elementequipped == 1)
        //    {
        //        focusOn = false;
        //        grabbedEarth.GetComponent<Rigidbody>().useGravity = true;
        //        grabbedEarth.GetComponent<Rigidbody>().AddForce((player.transform.position - focuspoint.transform.position) * -450.0f, ForceMode.Impulse);
        //        grabbedEarth = null;
        //    }
        //    if (heldfire != null && elementequipped == 4)
        //    {


        //        heldfire.GetComponent<Rigidbody>().AddForce((player.transform.position - focuspoint.transform.position) * -50.0f, ForceMode.Impulse);

        //    }
        //    if (nearbywater.Count > 0)
        //    {
        //        foreach (GameObject child in nearbywater)
        //        {
        //            child.GetComponent<Rigidbody>().useGravity = true;
        //        }

        //    }
        //    heldfire = null;
        //    nearbywater.Clear();
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    if (Input.GetMouseButton(1)) { }
        //    else
        //    {
        //        if (grabbedEarth != null)
        //        { grabbedEarth.GetComponent<Rigidbody>().useGravity = true; grabbedEarth = null; }
        //        if (nearbywater.Count > 0)
        //        {
        //            foreach (GameObject child in nearbywater)
        //            {
        //                child.GetComponent<Rigidbody>().useGravity = true;
        //            }

        //        }
        //        focusOn = false;
        //        nearbywater.Clear();
        //    }
        //}
        //if (Input.GetMouseButtonUp(1))
        //{
        //    if (Input.GetMouseButton(0)) { }
        //    else
        //    {
        //        if (grabbedEarth != null)
        //        { grabbedEarth.GetComponent<Rigidbody>().useGravity = true; grabbedEarth = null; }
        //        if (nearbywater.Count > 0)
        //        {
        //            foreach (GameObject child in nearbywater)
        //            {
        //                child.GetComponent<Rigidbody>().useGravity = true;
        //            }

        //        }
        //        focusOn = false;
        //        nearbywater.Clear();
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{ elementtypechange(1);  }
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{ elementtypechange(2);  }
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{ elementtypechange(3);  }
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{ elementtypechange(4);  }
    }


}