using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public int type,value; // 0: levels 1: games // which enviroment or game
    public Material color;
    public Color idColor;
    public GameObject colorIndicator;
    // Start is called before the first frame update
    void Start()
    {
        if(color != null){
            idColor = color.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConstructCartridge(Color newColor)
    {
        idColor = newColor;
        if (colorIndicator != null) { colorIndicator.GetComponent<Renderer>().material.color = newColor; }
        
    }
    public Color getIdColor()
    { return idColor; }
}
