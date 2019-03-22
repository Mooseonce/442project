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
    public GameObject greatJob;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
    }
    public void OnTriggerExit(Collider other)
    {

        if (timer <= 0)
        {
            timer = 0.4f;
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
                    if (greatJob != null) { Instantiate(greatJob, transform.position + (transform.right * 2) + (transform.up * 2), transform.rotation); }
                }
                else { otherTrigger.ready = false; }
            }
            else
            {
                if (ready == true) { otherTrigger.ready = true; }
                else { ready = true; }
            }
        }
    }

}
