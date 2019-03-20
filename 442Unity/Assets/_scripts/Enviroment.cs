using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public List<GameObject> objectToEnableOnSetup;
    public GameObject blankwall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //enable room specific objects that were disable to allow the room to 'slide' into place
    public void SetupRoom()
    {
        foreach (GameObject go in objectToEnableOnSetup)
        { go.active = true; }
    }
}
