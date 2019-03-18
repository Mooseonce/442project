using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using HTC.UnityPlugin.Utility;
using GrabberPool = HTC.UnityPlugin.Utility.ObjectPool<HTC.UnityPlugin.Vive.BasicGrabbable.Grabber>;
public class InWorldMenu : MonoBehaviour
       , IColliderEventHoverExitHandler
    , IColliderEventHoverEnterHandler
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler
{
    public List<InWorldMenu>  menuButtons;
    public List<GameObject> availableObjects; //objects that will be shown in menu
    public int menuType,menuPage; //main menu, page turn, item display || which group of objects to display
    public GameObject sitSpot,rootObject,displayedObject,realObject,spawnSpot,subObjects; //which decoration or toy this element is displaying, and the prefab it is made from
    public InWorldMenu mainMenu;
    public bool canSpawn,isMainMenu;
    public Material pressedColor,notPressedColor;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (isMainMenu == true) { }
        else
        {
         //   SetMenuItem(realObject);
        }

        switch (menuType)
        {
            case 0: //main menu
                UpdateMenuDisplayed(1);
                break;
            case 1: //page up
              //  mainMenu.UpdateMenuDisplayed(1);
                break;
            case 2: //page down
               // mainMenu.UpdateMenuDisplayed(-1);
                break;
            case 3: //itemspawn
                    //on controller grab spawn the real object represented by the menu item displayed here
                if (canSpawn == true)
                {
                   // canSpawn = false;

                  //  Instantiate(realObject, transform.position, transform.rotation);
                }
                break;

            default:

                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (menuType == 0) { rootObject.transform.position = sitSpot.transform.position; rootObject.transform.rotation = sitSpot.transform.rotation; }
        if (displayedObject != null) { displayedObject.transform.position = transform.position; displayedObject.transform.rotation = transform.rotation; }
        if (Input.GetKeyDown(KeyCode.A) && menuType == 0)
        { UpdateMenuDisplayed(-1); }
        if (Input.GetKeyDown(KeyCode.D) && menuType == 0)
        { UpdateMenuDisplayed(1); }
        transform.Rotate(0, rotSpeed, 0);
    }
    public void ToggleOn()
    { if (subObjects.active == false)
        { subObjects.active = true; }
        else { subObjects.active = false; }

    }

    public void SetMenuItem(GameObject newItem)
    {
        if (displayedObject != null) { Destroy(displayedObject); }

            canSpawn = true;
            realObject = newItem;
            displayedObject = Instantiate(realObject, transform.position, transform.rotation);
            displayedObject.transform.localScale = new Vector3(displayedObject.transform.localScale.x * 0.3f, displayedObject.transform.localScale.y * 0.3f, displayedObject.transform.localScale.z * 0.3f);
        if (displayedObject.GetComponent<Rigidbody>() != null) { displayedObject.GetComponent<Rigidbody>().isKinematic = true; }

        if (displayedObject.GetComponent<Collider>() != null)
        {
            //displayedObject.GetComponent<Collider>().enabled = false;
        }
            displayedObject.transform.parent = this.transform;
        
    }
    public void UpdateMenuDisplayed(int upOrDown)
    {
        int newPage = menuPage;
        int count = 0;
        while (count < menuButtons.Count)
        {
            newPage = newPage + upOrDown;
            if (newPage < 0) { newPage = availableObjects.Count - 1; }
            if (newPage  >= availableObjects.Count) { newPage = 0; }
            menuButtons[count].SetMenuItem(availableObjects[newPage]);
            count++;
        }
        menuPage = newPage;
    }
    public void SpawnObject(GameObject toSpawn,InWorldMenu buttonPressed,Vector3 loc)
    {
        if (canSpawn == true)
        {
            canSpawn = false;

           // GameObject clone = Instantiate(toSpawn, spawnSpot.transform.position, transform.rotation) as GameObject;
            //displayedObject.transform.parent = null;
            displayedObject.GetComponent<Rigidbody>().isKinematic = false;
            displayedObject.transform.localScale = new Vector3(displayedObject.transform.localScale.x / 0.3f, displayedObject.transform.localScale.y / 0.3f, displayedObject.transform.localScale.z / 0.3f);
            buttonPressed.displayedObject = null;
            buttonPressed.SetMenuItem(realObject);
        }
    }

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
       
        GetComponent<Renderer>().material = pressedColor;
        switch (menuType)
        {
            case 0: //main menu
               
                break;
            case 1: //page up
                mainMenu.UpdateMenuDisplayed(1);
                break;
            case 2: //page down
                mainMenu.UpdateMenuDisplayed(-1);
                break;
            case 3: //itemspawn
                    //on controller grab spawn the real object represented by the menu item displayed here
                if  (mainMenu != null && mainMenu.canSpawn == true)
                {
                    mainMenu.canSpawn = false;

                    GameObject clone = Instantiate(realObject, spawnSpot.transform.position, transform.rotation) as GameObject;
                    displayedObject.transform.parent = null;
                    displayedObject.GetComponent<Rigidbody>().isKinematic = false;
                    displayedObject.transform.localScale = new Vector3(displayedObject.transform.localScale.x / 0.3f, displayedObject.transform.localScale.y / 0.3f, displayedObject.transform.localScale.z / 0.3f);
                    displayedObject = null;
                    SetMenuItem(realObject);
                    //clone.GetComponent<Rigidbody>().useGravity = false;
                    //clone.GetComponent<Rigidbody>().isKinematic = true;
                    // SetAxis("HTC_VIU_UnityAxis1") = 0;
                    //   clone.SendMessage("IColliderEventDragStartHandler", eventData);
                    //if (eventData.pressEnteredObjects[0].transform != null)
                    //{
                    //    clone.transform.parent = eventData.pressEnteredObjects[0].transform.root;
                    //}
                }
                break;
         
            default:
          
                break;
        }

       
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        GetComponent<Renderer>().material = notPressedColor;
        switch (menuType)
        {
            case 0: //main menu

                break;
            case 1: //page up

                break;
            case 2: //page down

                break;
            case 3: //itemspawn
                   
              
                    canSpawn = true;

                break;

            default:

                break;
        }

    }
    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
       
        canSpawn = true;
    }

    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        canSpawn = false;
    }
}
