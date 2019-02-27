using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public GameObject itemToSpawn;
    public Transform spawnLocation;
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
            Instantiate(itemToSpawn,spawnLocation.position ,spawnLocation.rotation);
            timer = 1.0f; // to prevent the player from accidedntly double tapping.
        }
    }
}
