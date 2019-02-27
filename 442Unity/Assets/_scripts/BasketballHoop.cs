using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballHoop : MonoBehaviour
{
    public List<GameObject> scoreObjects;
    public List<Material> colors;
    public int score,tensPlace;
    public bool bottom,ready;
    public BasketballHoop otherTrigger; //if this is the bottom other trigger refers to the top, and vice versa
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit(Collider other)
    {
    

            if (bottom == true)
            {
                if (ready == true)
                {
                    ready = false;
                    scoreObjects[score].active = true;
                    scoreObjects[score].GetComponent<Renderer>().material = colors[tensPlace];
                    score++;
                    if (score >= scoreObjects.Count) { score = 0; tensPlace++; }
                    if (tensPlace >= colors.Count) { tensPlace = 0; }
                }
                else { otherTrigger.ready = false; }
            }
            else {
                    if (ready == true) { otherTrigger.ready = true; }
                    else { ready = true; }
                }
    }

}
