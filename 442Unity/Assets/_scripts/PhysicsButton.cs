using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    public float timer;
    public GameObject controlledObject;
    public int value, valueType;//value type for int/color/etc 
    public string messageToSend;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        { timer -= Time.deltaTime; }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && timer <= 0)
        {
            SendActionOnCollision();
            //controlledObject.SendMessage(messageToSend, value);
            //controlledObject.GetComponent<Cannon>().RotateCannon(value);
            timer = 0.1f; // to prevent the player from accidedntly double tapping.
        }
    }

    public void SendActionOnCollision()
    {
        switch (valueType)
        {
            //int type
            case 0:
                controlledObject.SendMessage(messageToSend, value);
                break;
            //color
            case 1:
                controlledObject.SendMessage(messageToSend, GetComponent<Renderer>().material.color);
                break;
            case 2:
                controlledObject.SendMessage(messageToSend);
                break;
            default:
                break;
                

                }
        }

    }


