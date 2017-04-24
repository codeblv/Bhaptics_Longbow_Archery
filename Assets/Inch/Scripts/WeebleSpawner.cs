using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeebleSpawner : MonoBehaviour {

    public Transform[] SpawnPoints;
    private float spawnTime = 1.0f;

    public GameObject Weeble;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnWeebles", spawnTime, spawnTime); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWeebles()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        GameObject TargetWeeble = Instantiate(Weeble, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        this.spawnTime = Random.Range(0, 2.0f);
    }
}
