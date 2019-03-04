using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    public float timer;
    public GameObject controlledObject;
    public int value;
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
            controlledObject.GetComponent<Cannon>().RotateCannon(value);
            timer = 0.1f; // to prevent the player from accidedntly double tapping.
        }
    }

}
