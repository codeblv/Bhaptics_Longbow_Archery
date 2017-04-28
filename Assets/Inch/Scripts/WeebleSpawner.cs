using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeebleSpawner : MonoBehaviour {

    // Defined in Unity Inspector
    public Transform[] SpawnPoints;
    public GameObject Weeble;

    // Private values
    private float spawnTime = 1.0f;
    private Transform player;
    private int numWeeble;
    
	// Use this for initialization
	void Start () {
        numWeeble = 0;

        // Get a player object
        Transform playerObj = GameObject.Find("Player").GetComponent<Transform>();
        if(playerObj != null)
        {
            player = playerObj;
        }

        // Start to spawn
        InvokeRepeating("SpawnWeebles", spawnTime, 3.0f); 
	}
    
    // Spawn ArcheryWeebles in random spawn points
    private void SpawnWeebles()
    {
        // Get a random spawn point to create weeble.
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        
        // Error Handling
        if(numWeeble < 0)
        {
            Debug.Log("Error: numWeeble can not be a negative number!");
            numWeeble = 0;
        }

        // Maximum number of weeble is 10
        if(numWeeble < 10)
        {
            GameObject TargetWeeble = Instantiate(Weeble, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
            numWeeble++;
            TargetWeeble.transform.LookAt(player);
            spawnTime = Random.Range(1.0f, 4.0f);
        }
    }

    //---------------------------------------------------------
    public void ModifyNumWeeble()
    {
        if (numWeeble > 0)
        {
            numWeeble--;
        }
    }
}
