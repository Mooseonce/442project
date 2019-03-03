using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public GameObject itemToSpawn;
    public Transform spawnLocation,spawnParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && timer <= 0)
        {
            GameObject clone = Instantiate(itemToSpawn,spawnLocation.position ,spawnLocation.rotation) as GameObject;
            clone.transform.parent = spawnParent;
            if (clone.active == false) { clone.active = true; }
            timer = 1.0f; // to prevent the player from accidedntly double tapping.
        }
    }
}
