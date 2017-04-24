using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeebleSpawner : MonoBehaviour {

    public Transform[] SpawnPoints;
    private float spawnTime = 1.0f;
    private Transform player;

    public GameObject Weeble;
	// Use this for initialization
	void Start () {
        Transform playerObj = GameObject.Find("Player").GetComponent<Transform>();
        if(playerObj != null)
        {
            player = playerObj;
        }
        InvokeRepeating("SpawnWeebles", spawnTime, spawnTime); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWeebles()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        GameObject TargetWeeble = Instantiate(Weeble, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        TargetWeeble.transform.LookAt(player);
        spawnTime = Random.Range(1.0f, 4.0f);
    }
}
