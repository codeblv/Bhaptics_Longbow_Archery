using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour {
    private bool haveTarget;

	// Use this for initialization
	void Start () {
        haveTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool HaveTarget()
    {
        return haveTarget;
    }
}
